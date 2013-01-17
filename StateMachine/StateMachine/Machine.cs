using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using StateMachine.Configuration;
using StateMachine.Processing;

namespace StateMachine
{
    public class Machine
    {
        private readonly IStateFactory _stateFactory;
        private readonly IStatePersister _persister;
        private readonly List<Prerequisite> _prerequisites = new List<Prerequisite>();
        private readonly List<Rule> _rules = new List<Rule>();
        private List<IState> _currentStates;
        private List<IState> _newStates; 

        public Machine(IStateFactory stateFactory, IStatePersister persister)
        {
            _stateFactory = stateFactory;
            _persister = persister;
        }

        public void Configure(Action<Prerequisite> action)
        {
            var prerequisite = new Prerequisite();
            action(prerequisite);
            _prerequisites.Add(prerequisite);
            _rules.Add(prerequisite.Rule);
        }

        public string GetDescriptions()
        {
            return string.Join(" | ", _prerequisites.Select(x => x.GetDescription()));
        }

        public void Initialize()
        {
            foreach (var state in _stateFactory.GetStates())
            {
                ConfigureTransitions(state);    
            }
        }

        private void ConfigureTransitions(IState state)
        {
            Rule rule = _rules.FirstOrDefault(r => r.RuleElements.Any(x => x.SourceType == state.GetType()));
            if(rule == null)
                return;
            
            RuleElement ruleElement = _rules.Select(x => x.GetRuleElement(state.GetType())).FirstOrDefault(x => x != null);
            if (ruleElement == null)
                return;

            var stateNames = new List<string>();
            foreach (var sourceEvent in ruleElement.SourceEvents)
            {
                var propertyInfo = (PropertyInfo) sourceEvent;
                var action = new Action(() =>
                                            {
                                                if (StateReached(propertyInfo.Name, stateNames))
                                                {
                                                    AdvanceState(rule.DestinationTypes);
                                                }
                                            });
                propertyInfo.SetValue(state, action);
                stateNames.Add(propertyInfo.Name);
            }
        }

        private bool StateReached(string state, List<string> states)
        {
            if (states.Contains(state))
            {
                states.Remove(state);
            }
            if (states.Count == 0)
            {
                return true;
            }

            return false;
        }

        private void AdvanceState(List<Type> destinationTypes)
        {
            if(!destinationTypes.Any())
               return;

            _newStates = new List<IState>();
            foreach (var destinationType in destinationTypes)
            {
                var state = _stateFactory.GetState(destinationType);
                _newStates.Add(state);
            }
        }

        public void Process(IData data)
        {
            _newStates = null;
            _currentStates = _persister.Get(data.Id);
            if (_currentStates == null || !_currentStates.Any())
            {
                _currentStates = new List<IState>();
                var sourceTypes = _rules.First().GetSourceTypes();
                foreach (var sourceType in sourceTypes)
                {
                    var state = _stateFactory.GetState(sourceType);
                    _currentStates.Add(state);
                }
            }

            foreach (var currentState in _currentStates)
            {
                currentState.Execute(data);
            }

            if (_newStates != null && _newStates.Any())
            {
                _currentStates = _newStates;
            }
            
            _persister.Set(data.Id, _currentStates);
        }
    }
}
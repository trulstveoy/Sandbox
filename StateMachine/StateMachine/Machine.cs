using System;
using System.Collections.Generic;
using System.Diagnostics;
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

        public void Initialize()
        {
            
        }

        public string GetDescriptions()
        {
            return string.Join(" | ", _prerequisites.Select(x => x.GetDescription()));
        }

        public void Process(IData data)
        {
            var currentStates = GetPersistedOrInitial(data);

            bool allSet = true;
            foreach (var currentStateTemp in currentStates)
            {
                var currentState = currentStateTemp;

                currentState.Execute(data);

                RuleElement ruleElement = _rules.Select(x => x.GetRuleElement(currentState.GetType())).FirstOrDefault(x => x != null);
                if (ruleElement == null)
                    Debug.Fail("Should always have an event or machine will never stop processing");

                bool currentSet = (from FieldInfo fieldInfo in ruleElement.SourceEvents select (Event) fieldInfo.GetValue(currentState)).All(@event => @event.IsSet);
                if (!currentSet)
                {
                    allSet = false;
                }
            }

            if (allSet)
            {
                Rule rule = _rules.FirstOrDefault(r => r.RuleElements.Any(x => x.SourceType == currentStates.First().GetType()));
                var newStates = _stateFactory.GetStates().Where(x => rule.DestinationTypes.Any(dest => dest == x.GetType()));
                currentStates = newStates.ToList(); 
            }
            
            _persister.Set(data.Id, currentStates);
        }

        private List<IState> GetPersistedOrInitial(IData data)
        {
            var persistedStates = _persister.Get(data.Id);
            var currentStates = new List<IState>();
            if(persistedStates != null)
                currentStates.AddRange(persistedStates);
            if (!currentStates.Any())
            {
                var sourceTypes = _rules.First().GetSourceTypes();
                currentStates.AddRange(sourceTypes.Select(sourceType => _stateFactory.GetState(sourceType)));
            }

            return currentStates;
        }
    }
}
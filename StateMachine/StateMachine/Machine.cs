using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using StateMachine.Configuration;

namespace StateMachine
{
    public class Machine
    {
        private readonly List<Prerequisite> _prerequisites = new List<Prerequisite>();
        private readonly List<State> _states = new List<State>();
        private readonly List<Rule> _rules = new List<Rule>(); 

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

        public void Initialize(State[] states)
        {
            _states.AddRange(states);

            var state = _states.First();

            RuleElement ruleElement = _rules.Select(x => x.GetRuleElement(state.GetType())).First(x => x != null);

            var actions = new List<Action>();
            foreach (var sourceEvent in ruleElement.SourceEvents)
            {
                var propertyInfo = (PropertyInfo)sourceEvent;
                var action = (Action)propertyInfo.GetValue(state);
                propertyInfo.SetValue(state, new Action(() => { ReachedState(action, actions); }));
                actions.Add(action);
            }
        }

        private void ReachedState(Action action, List<Action> actions)
        {
            if (actions.Contains(action))
            {
                actions.Remove(action);
            }
            if (actions.Count == 0)
            {
                
            }
        }

        public void Process()
        {
            var state = _states.First();
            state.Execute();
        }

        private void ReachedState(string name)
        {
            Trace.WriteLine("Reached state" + name);
        }
    }
}
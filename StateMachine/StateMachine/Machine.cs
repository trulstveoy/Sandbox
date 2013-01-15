﻿using System;
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

            var stateNames = new List<string>();
            foreach (var sourceEvent in ruleElement.SourceEvents)
            {
                var propertyInfo = (PropertyInfo)sourceEvent;
                var action = new Action(() =>
                                            {
                                                if (StateReached(propertyInfo.Name, stateNames))
                                                {
                                                    AdvanceState();
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

        private void AdvanceState()
        {
           
        }

        public void Process()
        {
            var state = _states.First();
            state.Execute();
        }
    }
}
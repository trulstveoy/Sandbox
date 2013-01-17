using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace StateMachine.Configuration
{
    public class Rule
    {
        private List<RuleElement> _ruleElements = new List<RuleElement>();
        public List<RuleElement> RuleElements
        {
            get { return _ruleElements; }
            set { _ruleElements = value; }
        }

        private List<Type> _destinationTypes = new List<Type>();
        public List<Type> DestinationTypes
        {
            get { return _destinationTypes; }
            set { _destinationTypes = value; }
        }

        public void AddSource(Type sourceType, MemberInfo member)
        {
            var ruleElement = RuleElements.FirstOrDefault(x => x.SourceType == sourceType);
            if (ruleElement == null)
            {
                ruleElement = new RuleElement(sourceType, member);
                _ruleElements.Add(ruleElement);
            }
            else
            {
                ruleElement.SourceEvents.Add(member);
            }
        }

        public RuleElement GetRuleElement(Type sourceType)
        {
            return _ruleElements.FirstOrDefault(x => x.SourceType == sourceType);
        }

        public List<Type> GetSourceTypes()
        {
            return RuleElements.Select(x => x.SourceType).Distinct().ToList();
        }
    }

    public class RuleElement
    {
        public Type SourceType { get; set; }

        private List<MemberInfo> _sourceEvents = new List<MemberInfo>();
        public List<MemberInfo> SourceEvents
        {
            get { return _sourceEvents; }
            set { _sourceEvents = value; }
        }

        public RuleElement(Type sourceType, MemberInfo member)
        {
            SourceType = sourceType;
            _sourceEvents.Add(member);
        }
    }

}
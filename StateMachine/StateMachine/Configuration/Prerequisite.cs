using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace StateMachine.Configuration
{
    public class Prerequisite
    {
        readonly Rule _rule = new Rule();

        public Rule Rule
        {
            get { return _rule; }
        }

        public string GetDescription()
        {
            var elements = _rule.RuleElements.Select(ruleElement => string.Format("{0}: {1}", ruleElement.SourceType.Name, string.Join(", ", ruleElement.SourceEvents.Select(x => x.Name)))).ToList();

            var destinationTypeNames = string.Join(", ", _rule.DestinationTypes.Select(x => x.Name));

            return string.Format("{0} -> {1}", string.Join(", ", elements), destinationTypeNames);
        }

        public Prerequisite Setup<T>(Expression<Func<T, Action>> expression)
        {
            var memberExpression = (MemberExpression) expression.Body;
            MemberInfo member = memberExpression.Member;

            _rule.AddSource(typeof(T), member);

            return this;
        }

        public Prerequisite TransitionTo<T2>()
        {
            _rule.DestinationTypes.Add(typeof(T2));

            return this;
        }


    }
}
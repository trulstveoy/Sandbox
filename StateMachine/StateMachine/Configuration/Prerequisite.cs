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
            var elements = _rule.RuleElements.Select(ruleElement => string.Format("{0}: {1}", ruleElement.SourceType.Name, 
                string.Join(", ", ruleElement.SourceEvents.Select(x => x.Name)))).ToList();

            var destinationTypeNames = string.Join(", ", _rule.DestinationTypes.Select(x => x.Name));

            return string.Format("{0} -> {1}", string.Join(", ", elements), destinationTypeNames);
        }

        public Type Source { get; private set; }
        public MemberInfo Member { get; private set; }
        public Type Destination { get; private set; }
        public Type InitialState { get; private set; }

        public Prerequisite Setup<T>(Expression<Func<T, Event>> expression) where T : IState 
        {
            var memberExpression = (MemberExpression) expression.Body;
            MemberInfo member = memberExpression.Member;

            _rule.AddSource(typeof(T), member);
            Source = typeof (T);
            Member = member;

            return this;
        }

        public Prerequisite TransitionTo<T>()
        {
            _rule.DestinationTypes.Add(typeof(T));
            Destination = typeof (T);

            return this;
        }


        public void SetInitialState<T>()
        {
            InitialState = typeof (T);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace StateMachine
{
    public class Machine
    {
        private readonly List<Prerequisite> _prerequisites = new List<Prerequisite>(); 

        public void Configure(Action<Prerequisite> action)
        {
            var prerequisite = new Prerequisite();
            action(prerequisite);
            _prerequisites.Add(prerequisite);
        }

        public string GetDescriptions()
        {
            return string.Join(",", _prerequisites.Select(x => x.Description));
        }

        public void Run(State state)
        {
            state.Execute();
        }
    }

    public class Prerequisite
    {
        public Prerequisite()
        {
            Description = "";
        }

        public string Description { get; private set; }

        public Prerequisite Setup<T>(Expression<Func<T, object>> expression)
        {
            string sourceName = typeof (T).Name;
            
            var memberExpression = (MemberExpression) expression.Body;
            var eventName = memberExpression.Member.Name;

            Description += string.Format(" {0}.{1}", sourceName, eventName);

            return this;
        }

        public Prerequisite TransitionTo<T2>()
        {
            Description += string.Format(" {0}",  typeof (T2).Name);
            return this;
        }
    }
}
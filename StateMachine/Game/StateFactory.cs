using System;
using System.Linq;
using System.Collections.Generic;
using Game.States;
using StateMachine;

namespace Game
{
    public class StateFactory : IStateFactory
    {
        private readonly List<State> _states = new List<State>
                                           {
                                               new EndOfRoadState(),
                                               new ForestState()
                                           } ; 

        public State GetState(Type type)
        {
            return _states.FirstOrDefault(x => x.GetType() == type);
        }

        public List<State> GetStates()
        {
            return _states;
        }
    }
}
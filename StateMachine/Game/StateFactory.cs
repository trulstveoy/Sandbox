using System;
using System.Linq;
using System.Collections.Generic;
using Game.States;
using StateMachine;

namespace Game
{
    public class StateFactory : IStateFactory
    {
        private readonly List<IState> _states = new List<IState>
                                           {
                                               new EndOfRoadState(),
                                               new ForestState()
                                           } ; 

        public IState GetState(Type type)
        {
            return _states.FirstOrDefault(x => x.GetType() == type);
        }

        public List<IState> GetStates()
        {
            return _states;
        }
    }
}
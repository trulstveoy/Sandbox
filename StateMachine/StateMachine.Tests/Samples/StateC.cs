﻿using System;
using System.Diagnostics;
using StateMachine.Processing;

namespace StateMachine.Tests.Samples
{
    public class StateC : IState
    {
        public Event Reached20 = new Event();
        
        public void Execute(IData data)
        {
            if (App.Worker.Value == 20)
            {
                Debug.WriteLine("Reached20");
                Reached20.Set();
            }
        }
    }
}
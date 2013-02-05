using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using StateMachine;

namespace Game
{
    public class StatePersister : IStatePersister
    {
        public List<IState> Get(Guid id)
        {
            try
            {
                var doc = File.ReadAllText(string.Format("{0}.json", id));
                var states = (List<IState>)JsonConvert.DeserializeObject(doc);
                return states;
            }
            catch (FileNotFoundException e)
            {
                return null;
            }
        }

        public void Set(Guid id, List<IState> states)
        {
            string document = JsonConvert.SerializeObject(states);
            File.WriteAllText(string.Format("{0}.json", id), document);
        }
    }
}
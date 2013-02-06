using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using StateMachine;

namespace Game
{
    public class StatePersister : IStatePersister
    {
        public List<State> Get(Guid id)
        {
            try
            {
                var stream = File.Open(string.Format("{0}.bin", id), FileMode.Open);
                var formatter = new BinaryFormatter();
                var states = (List<State>)formatter.Deserialize(stream);
                stream.Close();
                return states;
            }
            catch (FileNotFoundException e)
            {
                return null;
            }
        }

        public void Set(Guid id, List<State> states)
        {
            var stream = File.Open(string.Format("{0}.bin", id), FileMode.Create);
            var formatter = new BinaryFormatter();
            formatter.Serialize(stream, states);
            stream.Close();
        }
    }
}
using System;

namespace Messages
{
    public interface IEventMessage1
    {
        string Text { get; set; }
    }

    [Serializable]
    public class EventMessage1 : IEventMessage1
    {
        public string Text { get; set; }
    }
}

namespace StateMachine
{
    public class Event
    {
        public bool IsSet { get; set; }

        public void Set()
        {
            IsSet = true;
        }

        public void Unset()
        {
            IsSet = false;
        }
    }
}
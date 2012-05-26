namespace Uba_Engine
{
    public class Event
    {
        EventHandler _onEvent;
        float _delay;

        public Event(EventHandler onEvent, float delay)
        {
            _onEvent = onEvent;
            _delay = delay;
        }
    }
}

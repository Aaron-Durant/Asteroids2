using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Uba_Engine
{
    public class Event
    {
        eventHandler onEvent;
        float delay;

        public Event(eventHandler onEvent, float delay)
        {
            this.onEvent = onEvent;
            this.delay = delay;
        }
    }
}

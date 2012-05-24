using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Uba_Engine
{
    public class Event
    {
        EventHandler onEvent;
        float delay;

        public Event(EventHandler onEvent, float delay)
        {
            this.onEvent = onEvent;
            this.delay = delay;
        }
    }
}

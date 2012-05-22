using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Uba_Engine
{
    public delegate void spriteUpdate(Sprite s);

    public delegate void limitHit(LimitObject limitObject);

    public delegate void stateChanger();

    public delegate void setupDelegate();

    public delegate void eventHandler();
}

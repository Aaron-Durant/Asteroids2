﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Uba_Engine
{
    public delegate void SpriteUpdate(Sprite s);

    public delegate void LimitHit(LimitObject limitObject);

    public delegate void StateChanger();

    public delegate void SetupDelegate();

    public delegate void EventHandler();

    public delegate void Animation();
}

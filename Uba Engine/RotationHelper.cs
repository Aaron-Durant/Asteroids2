using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace Uba_Engine
{
    public class RotationHelper
    {

        public static Vector2 VelocityAtAngle(float velocity, Sprite sprite)
        {
            float x = velocity * (float) Math.Sin(sprite.Rotation);
            float y = velocity * (float) Math.Cos(sprite.Rotation);
            return new Vector2(x, y);
        }
    }
}

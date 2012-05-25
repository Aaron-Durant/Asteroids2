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

        /// <summary>
        /// Returns a vector2 with resultant velocity in the direction the Sprite is facing
        /// </summary>
        /// <param name="velocity">The velocity to move the Sprite</param>
        /// <param name="sprite">The Sprite to get Rotation from</param>
        /// <returns> Vector2 Holding a velocity </returns>
        public static Vector2 VelocityAtAngle(float velocity, Sprite sprite)
        {
            float x = velocity * (float) Math.Sin(sprite.Rotation);
            float y = velocity *-(float) Math.Cos(sprite.Rotation);
            return new Vector2(x, y);
        }
    }
}

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
    
    public class Limit
    {
        public static void limitInitialize(Sprite s, LimitHit onLimit, Rectangle limitBox)
        {
            s.onUpdate += checkLimit;
            s.limitBox = limitBox;
            s.onLimit = onLimit;
        }

        public static void checkLimit(Sprite s)
        {
            if (s.onLimit == wrap)
            {
                bool Top = (s.LowerBound) < (s.limitBox.Y);
                bool Bottom = (s.UpperBound) > (s.limitBox.Y + s.limitBox.Height);
                bool Right = (s.LeftBound) > s.limitBox.X + (s.limitBox.Width);
                bool Left = (s.RightBound) < (s.limitBox.X);

                if (Top) s.onLimit(new LimitObject(s, Direction.NORTH));
                else if (Bottom) s.onLimit(new LimitObject(s, Direction.SOUTH));
                else if (Right) s.onLimit(new LimitObject(s, Direction.EASTH));
                else if (Left) s.onLimit(new LimitObject(s, Direction.WEST));
            }
            else if (s.onLimit == bounce)
            {
                bool Top = (s.position.Y) < (s.limitBox.Y);
                bool Bottom = (s.position.Y + s.size.Y) > (s.limitBox.Y + s.limitBox.Height);
                bool Right = (s.position.X + s.size.X) > (s.limitBox.X + s.limitBox.Height);
                bool Left = (s.position.X) < (s.limitBox.X);

                if (Top) s.onLimit(new LimitObject(s, Direction.NORTH));
                else if (Bottom) s.onLimit(new LimitObject(s, Direction.SOUTH));
                else if (Right) s.onLimit(new LimitObject(s, Direction.EASTH));
                else if (Left) s.onLimit(new LimitObject(s, Direction.WEST));
            }
            
        }


        public static void wrap(LimitObject limitObject)
        {
            if (limitObject.direction == Direction.NORTH)
                limitObject.limitingSprite.position.Y += (limitObject.limitingSprite.limitBox.Height + limitObject.limitingSprite.size.Y);
            else if (limitObject.direction == Direction.SOUTH)
                limitObject.limitingSprite.position.Y -= (limitObject.limitingSprite.limitBox.Height + limitObject.limitingSprite.size.Y);
            else if (limitObject.direction == Direction.EASTH)
                limitObject.limitingSprite.position.X -= (limitObject.limitingSprite.limitBox.Width + limitObject.limitingSprite.size.X);
            else if (limitObject.direction == Direction.WEST)
                limitObject.limitingSprite.position.X += (limitObject.limitingSprite.limitBox.Width + limitObject.limitingSprite.size.X);
        }

        public static void bounce(LimitObject limitObject)
        {
            if (limitObject.direction == Direction.NORTH || limitObject.direction == Direction.SOUTH)
                limitObject.limitingSprite.velocity.Y *= -1;
            else if (limitObject.direction == Direction.EASTH || limitObject.direction == Direction.WEST)
                limitObject.limitingSprite.velocity.X *= -1;
        }
    }

    public class LimitObject
    {
        public Sprite limitingSprite;
        public Direction direction;

        public LimitObject(Sprite s, Direction direction)
        {
            limitingSprite = s;
            this.direction = direction;
        }
    }

}

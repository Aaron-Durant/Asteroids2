using Microsoft.Xna.Framework;

namespace Uba_Engine
{
    
    public class Limit
    {
        /// <summary>
        /// Initializes the Sprites limiting within the limitbox
        /// </summary>
        /// <param name="s"> The Sprite to limit </param>
        /// <param name="onLimit"> The Delegate to call when Sprite hits limitBox </param>
        /// <param name="limitBox"> The LimitBox the Sprite is confined to </param>
        public static void LimitInitialize(Sprite s, LimitHit onLimit, Rectangle limitBox)
        {
            s.OnUpdate += CheckLimit;
            s.LimitBox = limitBox;
            s.OnLimit = onLimit;
        }

        /// <summary>
        /// Checks if the Sprite has met its Limit criteria
        /// </summary>
        /// <param name="s"> The Sprite to check </param>
        public static void CheckLimit(Sprite s)
        {
            if (s.OnLimit == Wrap)
            {
                bool top = (s.LowerBound) < (s.LimitBox.Y);
                bool bottom = (s.UpperBound) > (s.LimitBox.Y + s.LimitBox.Height);
                bool right = (s.LeftBound) > s.LimitBox.X + (s.LimitBox.Width);
                bool left = (s.RightBound) < (s.LimitBox.X);

                if (top) s.OnLimit(new LimitObject(s, Direction.North));
                else if (bottom) s.OnLimit(new LimitObject(s, Direction.South));
                else if (right) s.OnLimit(new LimitObject(s, Direction.East));
                else if (left) s.OnLimit(new LimitObject(s, Direction.West));
            }
            else if (s.OnLimit == Bounce)
            {
                bool top = (s.Position.Y) < (s.LimitBox.Y);
                bool bottom = (s.Position.Y + s.Size.Y) > (s.LimitBox.Y + s.LimitBox.Height);
                bool right = (s.Position.X + s.Size.X) > (s.LimitBox.X + s.LimitBox.Height);
                bool left = (s.Position.X) < (s.LimitBox.X);

                if (top) s.OnLimit(new LimitObject(s, Direction.North));
                else if (bottom) s.OnLimit(new LimitObject(s, Direction.South));
                else if (right) s.OnLimit(new LimitObject(s, Direction.East));
                else if (left) s.OnLimit(new LimitObject(s, Direction.West));
            }
            
        }

        /// <summary>
        /// Wraps the Sprite round its LimitBox by moving to other side 
        /// </summary>
        /// <param name="limitObject"> The LimitObject holding data for Limiting </param>
        public static void Wrap(LimitObject limitObject)
        {
            if (limitObject.Direction == Direction.North)
                limitObject.LimitingSprite.Position.Y += (limitObject.LimitingSprite.LimitBox.Height + limitObject.LimitingSprite.Size.Y);
            else if (limitObject.Direction == Direction.South)
                limitObject.LimitingSprite.Position.Y -= (limitObject.LimitingSprite.LimitBox.Height + limitObject.LimitingSprite.Size.Y);
            else if (limitObject.Direction == Direction.East)
                limitObject.LimitingSprite.Position.X -= (limitObject.LimitingSprite.LimitBox.Width + limitObject.LimitingSprite.Size.X);
            else if (limitObject.Direction == Direction.West)
                limitObject.LimitingSprite.Position.X += (limitObject.LimitingSprite.LimitBox.Width + limitObject.LimitingSprite.Size.X);
        }

        /// <summary>
        /// Bounces the Sprite off the wall of the LimitBox
        /// </summary>
        /// <param name="limitObject"> The LimitObject holding data for Limiting </param>
        public static void Bounce(LimitObject limitObject)
        {
            if (limitObject.Direction == Direction.North || limitObject.Direction == Direction.South)
                limitObject.LimitingSprite.Velocity.Y *= -1;
            else if (limitObject.Direction == Direction.East || limitObject.Direction == Direction.West)
                limitObject.LimitingSprite.Velocity.X *= -1;
        }
    }

    public class LimitObject
    {
        public Sprite LimitingSprite;
        public Direction Direction;

        /// <summary>
        /// Creates a new LimitObject
        /// </summary>
        /// <param name="s"> The Sprite being limited </param>
        /// <param name="direction"> The Direction it has hit the LimitBox </param>
        public LimitObject(Sprite s, Direction direction)
        {
            LimitingSprite = s;
            Direction = direction;
        }
    }

}

using Microsoft.Xna.Framework;

namespace Uba_Engine
{

    public class Sprite : StaticSprite
    {
        /// <summary>
        /// Vector2s holding position, velocity and acceleration for each Sprite
        /// </summary>
        public Vector2 Position;
        public Vector2 Velocity;
        public Vector2 Acceleration;
        public Vector2 ChangeInAcceleration;

        /// <summary>
        /// The extreme points of the Sprite
        /// </summary>
        public int UpperBound { get { return (int) (Position.Y - Size.Y/2); } }
        public int LowerBound { get { return (int) (Position.Y + Size.Y/2); } }
        public int RightBound { get { return (int) (Position.X + Size.X/2); } }
        public int LeftBound  { get { return (int) (Position.X - Size.X/2); } }

        /// <summary>
        /// Is the sprite visible
        /// </summary>
        public bool Visible = true;
        /// <summary>
        /// Current Rotation of the Sprite
        /// </summary>
        public float Rotation;
        /// <summary>
        /// Current scale of the Sprite
        /// </summary>
        public Vector2 Scale = new Vector2(1, 1);
        /// <summary>
        /// Delegates to call on Sprite update
        /// </summary>
        public SpriteUpdate OnUpdate { get; set; }
        /// <summary>
        /// Holds a Rectangle representing the limit box of the Sprite
        /// </summary>
        public Rectangle LimitBox;
        /// <summary>
        /// Holds the delegate called when sprite hits limit box
        /// </summary>
        public LimitHit OnLimit;
        /// <summary>
        /// The engine that owns and draws the sprite
        /// </summary>
        public Engine Owner;

        /// <summary>
        /// Constructorfor the Sprite. Creates new frame and sets update delegates
        /// </summary>
        public Sprite() : base(new Vector2(0, 0))
        {
            Velocity = new Vector2(0, 0);
            Acceleration = new Vector2(0, 0);
            ChangeInAcceleration = new Vector2(0, 0);

            OnUpdate = UpdatePostition;
            OnUpdate += UpdateVelocity;
            OnUpdate += UpdateAcceleration;
        }

        /// <summary>
        /// updates the position of the Sprite by adding its velocity
        /// </summary>
        /// <param name="s"></param>
        static void UpdatePostition(Sprite s)
        {
            s.Position += s.Owner.EventM.ValuePerSecond(s.Velocity);
        }

        /// <summary>
        /// updates the velocity of the Sprite by adding acceleration
        /// </summary>
        /// <param name="s"></param>
        static void UpdateVelocity(Sprite s)
        {
            s.Velocity += s.Owner.EventM.ValuePerSecond(s.Acceleration);
        }

        /// <summary>
        /// Updates the acceleration of the Sprite
        /// </summary>
        /// <param name="s"></param>
        static void UpdateAcceleration(Sprite s)
        {
            s.Acceleration += s.Owner.EventM.ValuePerSecond(s.ChangeInAcceleration);
        }

        /// <summary>
        /// Initialises the Animator for the Sprite
        /// </summary>
        public void InitialiseAnimator()
        {
            Frame.Animator = new Animator(this);
        }

        /// <summary>
        /// Returns the Sprites centre of rotation
        /// </summary>
        /// <returns></returns>
        public Vector2 GetRotationCenter()
        {
            return Frame.GetCurrentSize()/2;
        }
    }
}

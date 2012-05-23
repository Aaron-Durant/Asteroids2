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

    public class Sprite : StaticSprite
    {
        /// <summary>
        /// Vector2s holding position, velocity and acceleration for each Sprite
        /// </summary>
        public Vector2 position;
        public Vector2 velocity;
        public Vector2 acceleration;
        public Vector2 changeInAcceleration;

        /// <summary>
        /// Is the sprite visible
        /// </summary>
        public bool visible = true;
        /// <summary>
        /// Delegates to call on Sprite update
        /// </summary>
        public spriteUpdate onUpdate { get; set; }
        /// <summary>
        /// Holds a Rectangle representing the limit box of the Sprite
        /// </summary>
        public Rectangle limitBox;
        /// <summary>
        /// Holds the delegate called when sprite hits limit box
        /// </summary>
        public limitHit onLimit;
        /// <summary>
        /// The engine that owns and draws the sprite
        /// </summary>
        public Engine owner;

        /// <summary>
        /// Constructorfor the Sprite. Creates new frame and sets update delegates
        /// </summary>
        public Sprite() : base(new Vector2(0, 0))
        {
            velocity = new Vector2(0, 0);
            acceleration = new Vector2(0, 0);
            changeInAcceleration = new Vector2(0, 0);

            onUpdate = UpdatePostition;
            onUpdate += UpdateVelocity;
            onUpdate += UpdateAcceleration;
        }

        /// <summary>
        /// updates the position of the Sprite by adding its velocity
        /// </summary>
        /// <param name="s"></param>
        static void UpdatePostition(Sprite s)
        {
            s.position += s.owner.eventM.ValuePerSecond(s.velocity);
        }

        /// <summary>
        /// updates the velocity of the Sprite by adding acceleration
        /// </summary>
        /// <param name="s"></param>
        static void UpdateVelocity(Sprite s)
        {
            s.velocity += s.owner.eventM.ValuePerSecond(s.acceleration);
        }

        /// <summary>
        /// Updates the acceleration of the Sprite
        /// </summary>
        /// <param name="s"></param>
        static void UpdateAcceleration(Sprite s)
        {
            s.acceleration += s.owner.eventM.ValuePerSecond(s.changeInAcceleration);
        }

    }
}

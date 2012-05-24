using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace Uba_Engine
{
    /// <summary>
    /// A Sprite that cannot move. Meant for splash screens and stuff
    /// </summary>
    public class StaticSprite
    {
        /// <summary>
        /// A Vector2 holding the position of the Sprite
        /// </summary>
        private Vector2 position;
        /// <summary>
        /// Returns postition of the sprite
        /// </summary>
        public Vector2 getPostition { get { return position; } }
        /// <summary>
        /// Holds the current size of the Sprite
        /// </summary>
        public Vector2 size = new Vector2(0, 0);
        /// <summary>
        /// The frame holding the textures for the Sprite
        /// </summary>
        public Frame frame;
        /// <summary>
        /// Color for the Sprite
        /// </summary>
        public Color color = Color.White;
        
        

        public StaticSprite(Vector2 Position)
        {
            position = Position;

            frame = new Frame(this);
        }
    }
}

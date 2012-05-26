using Microsoft.Xna.Framework;

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
        private Vector2 _position;
        /// <summary>
        /// Returns postition of the sprite
        /// </summary>
        public Vector2 getPostition { get { return _position; } }
        /// <summary>
        /// Holds the current size of the Sprite
        /// </summary>
        public Vector2 Size = Vector2.Zero;
        /// <summary>
        /// The frame holding the textures for the Sprite
        /// </summary>
        public Frame Frame;
        /// <summary>
        /// Color for the Sprite
        /// </summary>
        public Color color = Color.White;
        
        
        /// <summary>
        /// Creates a new StaticSprite. Sets its position and initialises its Frame 
        /// </summary>
        /// <param name="position"> The position of the StaticSprite. This cannot be changed later</param>
        public StaticSprite(Vector2 position)
        {
            _position = position;

            Frame = new Frame(this);
        }
    }
}

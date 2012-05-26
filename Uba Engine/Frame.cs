using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Uba_Engine
{
    public class Frame
    {
        /// <summary>
        /// Holds all the texures and rectangles associated with the Sprite
        /// </summary>
        public List<Texture2D> Textures = new List<Texture2D>();
        public List<Rectangle> Rectangles = new List<Rectangle>();

        /// <summary>
        /// The current frame the animation is on and the total frames
        /// </summary>
        internal int CurrentFrame;
        internal int TotalFrames;

        /// <summary>
        /// The Sprite that the Frame belongs to 
        /// </summary>
        StaticSprite ownerSprite;

        /// <summary>
        /// The animator associated with the Frame
        /// </summary>
        public Animator Animator;

        /// <summary>
        /// Constructor for the Frame
        /// </summary>
        /// <param name="owner"> The StaticSprite the Frame belongs to </param>
        public Frame(StaticSprite owner)
        {
            ownerSprite = owner;
            CurrentFrame = 0;
            TotalFrames = 0;
        }

        /// <summary>
        /// Adds a new Texture and Rectangle to the lists of Textures and Rectangles that define the Sprite
        /// </summary>
        /// <param name="texture"> The Texture that the image is in </param>
        /// <param name="position"> The position in the Texture that the image can be found </param>
        public void Define(Texture2D texture, Rectangle position)
        {
            Textures.Add(texture);
            Rectangles.Add(position);
            TotalFrames++;
            ownerSprite.Size = GetCurrentSize();
        }

        /// <summary>
        /// Returns the current size of the Sprite
        /// </summary>
        /// <returns></returns>
        public Vector2 GetCurrentSize()
        {
            Rectangle currentRectangle = Rectangles[CurrentFrame];
            return new Vector2(currentRectangle.Width, currentRectangle.Height);
        }

        /// <summary>
        /// Changed to the next frame to show a different image for the Sprite
        /// </summary>
        public void NextFrame()
        {
            CurrentFrame++;
            if (CurrentFrame == TotalFrames) CurrentFrame = 0;
        }
    }
}

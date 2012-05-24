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

        StaticSprite ownerSprite;

        public Animator Animator;

        public Frame(StaticSprite owner)
        {
            ownerSprite = owner;
            CurrentFrame = 0;
            TotalFrames = 0;
        }


        public void Define(Texture2D texture, Rectangle position)
        {
            Textures.Add(texture);
            Rectangles.Add(position);
            TotalFrames++;
            ownerSprite.size = GetCurrentSize();
        }

        public Vector2 GetCurrentSize()
        {
            Rectangle currentRectangle = Rectangles[CurrentFrame];
            return new Vector2(currentRectangle.Width, currentRectangle.Height);
        }

        public void NextFrame()
        {
            CurrentFrame++;
            if (CurrentFrame == TotalFrames) CurrentFrame = 0;
        }

        public void Update()
        {

        }


    }
}

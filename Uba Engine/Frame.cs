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
    public class Frame
    {
        public List<Texture2D> textures = new List<Texture2D>();
        public List<Rectangle> rectangles = new List<Rectangle>();

        internal int currentFrame = 0;

        Sprite ownerSprite;

        public Frame(Sprite owner)
        {
            ownerSprite = owner;
        }

        public void define(Texture2D texture, Rectangle position)
        {
            textures.Add(texture);
            rectangles.Add(position);
            ownerSprite.size = new Rectangle(0, 0, position.Width, position.Height);
        }

    }
}

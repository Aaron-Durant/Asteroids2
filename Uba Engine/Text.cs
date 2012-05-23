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
    public class Text
    {
        public SpriteFont Font;
        public String text;
        public Vector2 Position;
        public Color TextColor;

        public Text(SpriteFont font, String text, Vector2 position, Color color)
        {
            Font = font;
            this.text = text;
            Position = position;
            TextColor = color;
        }
    }
}

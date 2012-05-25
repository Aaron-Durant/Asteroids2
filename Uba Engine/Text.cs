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
        public Vector2 Size { get { return Font.MeasureString(text); } }
        public Vector2 Scale = new Vector2(1f);
        public Align Alignment;

        public Text(SpriteFont font, String text, Vector2 position, Color color, Align alignment)
        {
            Font = font;
            this.text = text;
            Position = position;
            TextColor = color;
            Alignment = alignment;
        }

        /// <summary>
        /// Constructor for Text object to be used only when creating Text object for Menus as other properties are defined in the menu
        /// </summary>
        /// <param name="text"></param>
        public Text(String text)
        {
            this.text = text;
        }
    }
}

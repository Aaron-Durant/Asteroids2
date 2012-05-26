using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace Uba_Engine
{
    public class Text
    {
        /// <summary>
        /// Font used to draw Text
        /// </summary>
        public SpriteFont Font;
        /// <summary>
        /// The String the Text will display
        /// </summary>
        public String text;
        /// <summary>
        /// The Position of the Text
        /// </summary>
        public Vector2 Position;
        /// <summary>
        /// The Color of the text
        /// </summary>
        public Color TextColor;
        /// <summary>
        /// Returns the size of the Text in the current font
        /// </summary>
        public Vector2 Size { get { return Font.MeasureString(text); } }
        /// <summary>
        /// The scale of the Text
        /// </summary>
        public Vector2 Scale = new Vector2(1f);
        /// <summary>
        /// The alignment of the Text
        /// </summary>
        public Align Alignment;

        /// <summary>
        /// Creates a new Text object
        /// </summary>
        /// <param name="font"> The font to use for the Text </param>
        /// <param name="text"> The text to display </param>
        /// <param name="position"> The position of the Text </param>
        /// <param name="color"> The color of the Text </param>
        /// <param name="alignment"> The alignment of the Text </param>
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

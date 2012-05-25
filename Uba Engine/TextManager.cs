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
    public class TextManager : DrawableGameComponent
    {
        /// <summary>
        /// List of Text objects to be drawn on screen this update
        /// </summary>
        List<Text> Texts;
        /// <summary>
        /// A SpriteBatch to draw the text
        /// </summary>
        SpriteBatch spriteBatch;

        /// <summary>
        /// Default constructor for TextManager
        /// </summary>
        /// <param name="g"></param>
        public TextManager(Game g)
            : base(g)
        {
            Texts = new List<Text>();
            IGraphicsDeviceService GraphicsDeviceService = (IGraphicsDeviceService)g.Services.GetService(typeof(IGraphicsDeviceService));
            spriteBatch = new SpriteBatch(GraphicsDeviceService.GraphicsDevice);
        }

        /// <summary>
        /// Draws the Text to the screen
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();

            foreach (Text text in Texts)
            {
                Vector2 position = CalculatePosition(text);
                spriteBatch.DrawString(text.Font, text.text, position, text.TextColor, 0f, new Vector2(), text.Scale, SpriteEffects.None, 0 );
            }

            spriteBatch.End();
            ClearTexts();
 	        base.Draw(gameTime);
        }

        public Vector2 CalculatePosition(Text t)
        {
            switch (t.Alignment)
            {
                case Align.bottomLeft:
                    return t.Position - new Vector2(0, t.Size.Y);
                case Align.bottom:
                    return t.Position - new Vector2(t.Size.X/2, t.Size.Y);
                case Align.bottomRight:
                    return t.Position - t.Size;
                case Align.right:
                    return t.Position - new Vector2(t.Size.X, t.Size.Y/2);
                case Align.topRight:
                    return t.Position - new Vector2(t.Size.X, 0);
                case Align.top:
                    return t.Position - new Vector2(t.Size.X/2, 0);
                case Align.topLeft:
                    return t.Position;
                case Align.left:
                    return t.Position - new Vector2(0, t.Size.Y/2);
                case Align.center:
                    return t.Position - (t.Size / 2);
                default:
                    return t.Position;

            }
        }

        public void AddText(Text t)
        {
            if (!Texts.Contains(t)) Texts.Add(t);
        }

        public void ClearTexts()
        {
            Texts.Clear();
        }



    }
}

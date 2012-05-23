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
                spriteBatch.DrawString(text.Font, text.text, text.Position, text.TextColor);
            }

            spriteBatch.End();
            ClearTexts();
 	        base.Draw(gameTime);
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

using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Uba_Engine
{
    public class TextManager : DrawableGameComponent
    {
        /// <summary>
        /// List of Text objects to be drawn on screen this update
        /// </summary>
        List<Text> _texts;
        /// <summary>
        /// A SpriteBatch to draw the text
        /// </summary>
        SpriteBatch _spriteBatch;

        /// <summary>
        /// Default constructor for TextManager
        /// </summary>
        /// <param name="g"></param>
        public TextManager(Game g)
            : base(g)
        {
            _texts = new List<Text>();
            IGraphicsDeviceService GraphicsDeviceService = (IGraphicsDeviceService)g.Services.GetService(typeof(IGraphicsDeviceService));
            _spriteBatch = new SpriteBatch(GraphicsDeviceService.GraphicsDevice);
        }

        /// <summary>
        /// Draws the Text to the screen
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Draw(GameTime gameTime)
        {
            _spriteBatch.Begin();

            foreach (Text text in _texts)
            {
                Vector2 position = CalculatePosition(text);
                _spriteBatch.DrawString(text.Font, text.text, position, text.TextColor, 0f, new Vector2(), text.Scale, SpriteEffects.None, 0 );
            }

            _spriteBatch.End();
            ClearTexts();
 	        base.Draw(gameTime);
        }

        /// <summary>
        /// Calculates the position the Text should be drawn at given its alignment
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public Vector2 CalculatePosition(Text t)
        {
            switch (t.Alignment)
            {
                case Align.BottomLeft:
                    return t.Position - new Vector2(0, t.Size.Y);
                case Align.Bottom:
                    return t.Position - new Vector2(t.Size.X/2, t.Size.Y);
                case Align.BottomRight:
                    return t.Position - t.Size;
                case Align.Right:
                    return t.Position - new Vector2(t.Size.X, t.Size.Y/2);
                case Align.TopRight:
                    return t.Position - new Vector2(t.Size.X, 0);
                case Align.Top:
                    return t.Position - new Vector2(t.Size.X/2, 0);
                case Align.TopLeft:
                    return t.Position;
                case Align.Left:
                    return t.Position - new Vector2(0, t.Size.Y/2);
                case Align.Center:
                    return t.Position - (t.Size / 2);
                default:
                    return t.Position;

            }
        }

        /// <summary>
        /// Adds a new Text to the list of texts to be drawn if it is not already in the list
        /// </summary>
        /// <param name="t"></param>
        public void AddText(Text t)
        {
            if (!_texts.Contains(t)) _texts.Add(t);
        }

        /// <summary>
        /// Removes all texts from the list of texts. This is called every Draw
        /// </summary>
        public void ClearTexts()
        {
            _texts.Clear();
        }



    }
}

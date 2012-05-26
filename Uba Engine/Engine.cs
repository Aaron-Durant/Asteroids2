using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Uba_Engine
{
    public class Engine : DrawableGameComponent
    {
        /// <summary>
        /// GraphicsDeviceManager and SpriteBatch being used by the engine
        /// </summary>
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        /// <summary>
        /// A list of all currently active sprites
        /// </summary>
        List<Sprite> spriteList;
        /// <summary>
        /// A list of all curently active staticSprites
        /// </summary>
        private List<StaticSprite> staticSpriteList; 
        /// <summary>
        /// The current update rate of the engine
        /// </summary>
        public float UpdateRate { get { return EventM.GameUPS; } }
        /// <summary>
        /// Holds a delegate to run when state is changed
        /// </summary>
        public StateChanger NewState;
        /// <summary>
        /// The EventManager associated with the Engine
        /// </summary>
        public EventManager EventM;
        /// <summary>
        /// The MenuManager associated with the Engine
        /// </summary>
        public MenuManager MenuM;

        /// <summary>
        /// Default Constructor for the Engine object
        /// </summary>
        /// <param name="g"> The Game object the Engine runs </param>
        /// <param name="eventM"> The EventManager object associated with the Engine </param>
        /// <param name="menuM"> The MenuManager object associated with the Engine </param>
        public Engine(Game g, EventManager eventM, MenuManager menuM) : base(g)
        {
            graphics = (GraphicsDeviceManager)g.Services.GetService(typeof (IGraphicsDeviceManager));
            IGraphicsDeviceService graphicsDeviceService = (IGraphicsDeviceService)g.Services.GetService(typeof(IGraphicsDeviceService));
            spriteBatch = new SpriteBatch(graphicsDeviceService.GraphicsDevice);
            this.EventM = eventM;
            this.MenuM = menuM;
            spriteList = new List<Sprite>();
            staticSpriteList = new List<StaticSprite>();
        }

        /// <summary>
        /// Sets the screen size
        /// </summary>
        /// <param name="width"> The new width of the screen </param>
        /// <param name="height"> The new height of the screen </param>
        public void SetScreen(int width, int height)
        {
            graphics.PreferredBackBufferWidth = width;
            graphics.PreferredBackBufferHeight = height;
            graphics.ApplyChanges();
        }

        /// <summary>
        /// Updates the Engine. Updates all Sprites in the Engine and checks for new state
        /// </summary>
        /// <param name="gameTime"> GameTime object holding timing data </param>
        public override void Update(GameTime gameTime)
        {

            foreach (Sprite s in spriteList)
            {
                s.OnUpdate(s);
            }

            if (NewState != null)
            {
                StateChanger newGameState = NewState;
                NewState = null;
                newGameState();
            }


            base.Update(gameTime);

        }

        /// <summary>
        /// Adds a Sprite to the Engine's list of Sprites
        /// </summary>
        /// <param name="s"> The Sprite to add to the Engine </param>
        public void AddSprite(Sprite s)
        {
            spriteList.Add(s);
            s.Owner = this;
        }

        /// <summary>
        /// Adds a StaticSprite to the Engine's list of StaticSprites
        /// </summary>
        /// <param name="s"></param>
        public void AddStaticSprite(StaticSprite s)
        {
            staticSpriteList.Add(s);
        }

        /// <summary>
        /// Draws all the Sprites in the Engine
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            foreach (Sprite s in spriteList)
            {
                if (s.Visible)
                {
                    spriteBatch.Draw(s.Frame.Textures[s.Frame.CurrentFrame], s.Position, s.Frame.Rectangles[s.Frame.CurrentFrame], s.color, s.Rotation, s.GetRotationCenter(), s.Scale, SpriteEffects.None, 0);
                }
            }

            foreach (StaticSprite staticSprite in staticSpriteList )
            {
                spriteBatch.Draw(staticSprite.Frame.Textures[staticSprite.Frame.CurrentFrame], staticSprite.getPostition, staticSprite.Frame.Rectangles[staticSprite.Frame.CurrentFrame], staticSprite.color);
            }
            spriteBatch.End();

            base.Draw(gameTime);
        }

        /// <summary>
        /// Clears all Assets currently active
        /// </summary>
        public void ClearAllAssets()
        {
            staticSpriteList.Clear();
            spriteList.Clear();
            MenuM.HideAllMenus();
        }

        /// <summary>
        /// Exits the engine
        /// </summary>
        public void Exit()
        {
            Game.Exit();
        }
    }
}

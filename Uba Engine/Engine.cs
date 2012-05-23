using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

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
        float updateRate = 0.0f;
        /// <summary>
        /// Is the engine running?
        /// </summary>
        bool running = true;
        /// <summary>
        /// Holds a delegate to run when state is changed
        /// </summary>
        public stateChanger newState = null;
        /// <summary>
        /// The EventManager associated with the engine
        /// </summary>
        public EventManager eventM;
        

        public Engine(Game g, EventManager eventM) : base(g)
        {
            graphics = (GraphicsDeviceManager)g.Services.GetService(typeof (IGraphicsDeviceManager));
            IGraphicsDeviceService GraphicsDeviceService = (IGraphicsDeviceService)g.Services.GetService(typeof(IGraphicsDeviceService));
            spriteBatch = new SpriteBatch(GraphicsDeviceService.GraphicsDevice);
            this.eventM = eventM;
            spriteList = new List<Sprite>();
            staticSpriteList = new List<StaticSprite>();
        }

        public void setScreen(int width, int height)
        {
            graphics.PreferredBackBufferWidth = width;
            graphics.PreferredBackBufferHeight = height;
            graphics.ApplyChanges();
        }

        public override void Update(GameTime gameTime)
        {

            foreach (Sprite s in spriteList)
            {
                s.onUpdate(s);
            }

            if (newState != null)
            {
                stateChanger newGameState = newState;
                newState = null;
                newGameState();
            }


            base.Update(gameTime);

        }


        protected override void LoadContent()
        {
            base.LoadContent();
        }

        public void addSprite(Sprite s)
        {
            spriteList.Add(s);
            s.owner = this;
        }

        public void AddStaticSprite(StaticSprite s)
        {
            staticSpriteList.Add(s);
        }

        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            foreach (Sprite s in spriteList)
            {
                if (s.visible)
                {
                    spriteBatch.Draw(s.frame.textures[s.frame.currentFrame], s.position, s.frame.rectangles[s.frame.currentFrame], s.color);
                }
            }

            foreach (StaticSprite staticSprite in staticSpriteList )
            {
                spriteBatch.Draw(staticSprite.frame.textures[staticSprite.frame.currentFrame], staticSprite.getPostition, staticSprite.frame.rectangles[staticSprite.frame.currentFrame], staticSprite.color);
            }
            spriteBatch.End();

            base.Draw(gameTime);
        }

        public float getUpdateRate()
        {
            return updateRate;
        }

        public void clearAllAssets()
        {
            staticSpriteList.Clear();
            spriteList.Clear();
        }

        /// <summary>
        /// Exits the engine
        /// </summary>
        public void Exit()
        {
            running = false;
            Game.Exit();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;

using Uba_Engine;

namespace Asteroids_2
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public partial class Game1 : Microsoft.Xna.Framework.Game
    {
        /// <summary>
        /// GraphicsDeviceManager and SpriteBatch being used by the game
        /// </summary>
        public GraphicsDeviceManager graphics;
        
        /// <summary>
        /// Holds the Engine object
        /// </summary>
        public Engine engine;
        /// <summary>
        /// Holds the InputManager object
        /// </summary>
        public InputManager inputM;
        /// <summary>
        /// Holds the LoadManager object
        /// </summary>
        public LoadManager loadM;
        /// <summary>
        /// Holds the SetupManager object
        /// </summary>
        public SetupManager setupM;
        /// <summary>
        /// Holds the EventManager object
        /// </summary>
        public EventManager eventM;
        /// <summary>
        /// Holds the TextManager object
        /// </summary>
        public TextManager textM;
        /// <summary>
        /// Rectangle holding the screen size
        /// </summary>
        public Rectangle screenSize = new Rectangle(0, 0, 1280, 720);
        /// <summary>
        /// Holds the current game state;
        /// </summary>
        public int gameState;


        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {

            // Initializes engine subsystems
            
            // Initializes the inputManager object
            inputM = new InputManager(this);
            // Initializes the eventManager object. Sets updates to 100/second and keeps draws at 60/second.
            eventM = new EventManager(this, 100, true);
            // Initializes the loadManager object
            loadM = new LoadManager(this);
            // Initializes the setupManager object
            setupM = new SetupManager();
            // Initializes the textManager object
            textM = new TextManager(this);
            // Initializes the engine object
            engine = new Engine(this, eventM);

            Components.Add(inputM);
            Components.Add(eventM);
            Components.Add(loadM);
            Components.Add(textM);
            Components.Add(engine);

            //// Set screen size 
            engine.setScreen(screenSize.Width, screenSize.Height);

            

            base.Initialize();

            
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            gameState = GameState.loading;
            // TODO: use this.Content to load your game content here

            // Add textures to loadManager
            loadM.addTexture("Graphics\\UbaGameStudioLogo"); // Asset 0
            loadM.addTexture("Graphics\\SampleTexture"); // Asset 1

            // Add SpriteFonts to loadManager
            loadM.addFont("Fonts\\Debug"); // Asset 2

            // Start loadManager
            loadM.start(500);
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {

            // Main Game loop
            gameLoop();
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            base.Draw(gameTime);
        }
    }
}

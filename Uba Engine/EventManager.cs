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
    public class EventManager : DrawableGameComponent
    {
        /// <summary>
        /// Current frame rate the engine is running at
        /// </summary>
        private int framesPerSecond = 0;
        /// <summary>
        /// The total time since frames were last counted
        /// </summary>
        private float totalFrameTime = 0;
        /// <summary>
        /// No of frames since frames were last counted
        /// </summary>
        private int noOfFrames = 0;
        /// <summary>
        /// Current update rate the engine is running at
        /// </summary>
        private int updatesPerSecond = 0;
        /// <summary>
        /// The total time since the updates were last counted
        /// </summary>
        private float totalUpdateTime = 0;
        /// <summary>
        /// No of updates since updates were last counted
        /// </summary>
        private int noOfUpdates = 0;
        /// <summary>
        /// The update rate then engine is attempting to run at
        /// </summary>
        private int targetUpdateRate;

        public int GameFPS { get { return framesPerSecond; } }
        public int GameUPS { get { return updatesPerSecond; } }

        /// <summary>
        /// Creates a new EventManager 
        /// </summary>
        /// <param name="g"> The Game object associated with the EventManager </param>
        /// <param name="targetUpdateRate"> The number of updates per second you want the game to run at (It may not run at this speed)
        /// Setting this to less than 0 will update as fast as possible</param>
        /// <param name="synchroniseWithRetrace"> If set to true, the Game will draw at 60fps. If set to false, the game will draw at the update rate </param>
        public EventManager(Game g, int targetUpdateRate, bool synchroniseWithRetrace) : base(g)
        {
            this.targetUpdateRate = targetUpdateRate;
            if (targetUpdateRate > 0) g.TargetElapsedTime = TimeSpan.FromMilliseconds(1000.0f / (float)targetUpdateRate);
            if (targetUpdateRate < 0) g.IsFixedTimeStep = false;
            if (targetUpdateRate == 0) this.targetUpdateRate = 100; g.TargetElapsedTime = TimeSpan.FromMilliseconds(1000.0f / 100.0f);

            GraphicsDeviceManager graphics = (GraphicsDeviceManager)g.Services.GetService(typeof(IGraphicsDeviceManager));
            graphics.SynchronizeWithVerticalRetrace = synchroniseWithRetrace;
        }

        /// <summary>
        /// Calculates the update rate of the engine
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Update(GameTime gameTime)
        {
            // Calculate UPS
            if (totalUpdateTime > 1000)
            {
                totalUpdateTime -= 1000;
                updatesPerSecond = noOfUpdates;
                noOfUpdates = 0;
                Console.WriteLine("Updates: " + updatesPerSecond + " Frames: " + framesPerSecond);
            }
            totalUpdateTime += (float)gameTime.ElapsedGameTime.TotalMilliseconds;
            noOfUpdates++;

            base.Update(gameTime);
        }
        
        /// <summary>
        /// Calculate the draw rate of the engine
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Draw(GameTime gameTime)
        {
            // Calculate FPS
            if (totalFrameTime > 1000)
            {
                totalFrameTime -= 1000;
                framesPerSecond = noOfFrames;
                noOfFrames = 0;
            }
            totalFrameTime += (float)gameTime.ElapsedGameTime.TotalMilliseconds;
            noOfFrames++;


            base.Draw(gameTime);
        }

        public float ValuePerSecond(float value)
        {
            return value/updatesPerSecond;
        }

        public Vector2 ValuePerSecond(Vector2 value)
        {
            return value/updatesPerSecond;
        }
    }
}

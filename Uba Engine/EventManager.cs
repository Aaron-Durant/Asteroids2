using System;
using Microsoft.Xna.Framework;

namespace Uba_Engine
{
    public class EventManager : DrawableGameComponent
    {
        /// <summary>
        /// Current frame rate the engine is running at
        /// </summary>
        private int _framesPerSecond;
        /// <summary>
        /// The total time since frames were last counted
        /// </summary>
        private float _totalFrameTime;
        /// <summary>
        /// No of frames since frames were last counted
        /// </summary>
        private int _noOfFrames;
        /// <summary>
        /// Current update rate the engine is running at
        /// </summary>
        private int _updatesPerSecond;
        /// <summary>
        /// The total time since the updates were last counted
        /// </summary>
        private float _totalUpdateTime;
        /// <summary>
        /// No of updates since updates were last counted
        /// </summary>
        private int _noOfUpdates;
        /// <summary>
        /// The update rate then engine is attempting to run at
        /// </summary>
        private int _targetUpdateRate;
        /// <summary>
        /// Returns the Update and Frame rates of the Game
        /// </summary>
        public int GameFPS { get { return _framesPerSecond; } }
        public int GameUPS { get { return _updatesPerSecond; } }

        /// <summary>
        /// Creates a new EventManager 
        /// </summary>
        /// <param name="g"> The Game object associated with the EventManager </param>
        /// <param name="targetUpdateRate"> The number of updates per second you want the game to run at (It may not run at this speed)
        /// Setting this to less than 0 will update as fast as possible</param>
        /// <param name="synchroniseWithRetrace"> If set to true, the Game will draw at 60fps. If set to false, the game will draw at the update rate </param>
        public EventManager(Game g, int targetUpdateRate, bool synchroniseWithRetrace) : base(g)
        {
            _targetUpdateRate = targetUpdateRate;
            if (targetUpdateRate > 0) g.TargetElapsedTime = TimeSpan.FromMilliseconds(1000.0f / targetUpdateRate);
            if (targetUpdateRate < 0) g.IsFixedTimeStep = false;
            if (targetUpdateRate == 0) _targetUpdateRate = 100; g.TargetElapsedTime = TimeSpan.FromMilliseconds(1000.0f / 100.0f);

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
            if (_totalUpdateTime > 1000)
            {
                _totalUpdateTime -= 1000;
                _updatesPerSecond = _noOfUpdates;
                _noOfUpdates = 0;
            }
            _totalUpdateTime += (float)gameTime.ElapsedGameTime.TotalMilliseconds;
            _noOfUpdates++;

            base.Update(gameTime);
        }
        
        /// <summary>
        /// Calculate the draw rate of the engine
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Draw(GameTime gameTime)
        {
            // Calculate FPS
            if (_totalFrameTime > 1000)
            {
                _totalFrameTime -= 1000;
                _framesPerSecond = _noOfFrames;
                _noOfFrames = 0;
            }
            _totalFrameTime += (float)gameTime.ElapsedGameTime.TotalMilliseconds;
            _noOfFrames++;


            base.Draw(gameTime);
        }

        /// <summary>
        /// Converts a value into a value per second, so the value is added over a second rather than per update
        /// </summary>
        /// <param name="value"> The value to be converted </param>
        /// <returns></returns>
        public float ValuePerSecond(float value)
        {
            return value/_updatesPerSecond;
        }

        /// <summary>
        /// Converts a Vector2 into a value per second, so the Vector2 is added over a second rather than per update
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public Vector2 ValuePerSecond(Vector2 value)
        {
            return value/_updatesPerSecond;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Uba_Engine
{
    public class InputManager : DrawableGameComponent
    {
        /// <summary>
        /// Variables to holds states of keyboards and gamepads
        /// </summary>
        KeyboardState latestKeyboardState;
        KeyboardState oldestKeyboardState;
        GamePadState[] gamePads = new GamePadState[8];
        
        /// <summary>
        /// Initialises the InputManager.
        /// Gets initial states of keyboard and gamepads
        /// </summary>
        public InputManager(Game g) : base(g)
        {
            latestKeyboardState = Keyboard.GetState();
            gamePads[0] = GamePad.GetState(PlayerIndex.One);
            gamePads[1] = GamePad.GetState(PlayerIndex.Two);
            gamePads[2] = GamePad.GetState(PlayerIndex.Three);
            gamePads[3] = GamePad.GetState(PlayerIndex.Four);
        }

        /// <summary>
        /// Sets old keyboard and gamepad states to those from previous update
        /// Gets new keyboard and gamepad states
        /// </summary>
        public override void Update(GameTime gameTime)
        {
            oldestKeyboardState = latestKeyboardState;
            latestKeyboardState = Keyboard.GetState();
            gamePads[4] = gamePads[0];
            gamePads[0] = GamePad.GetState(PlayerIndex.One);
            gamePads[5] = gamePads[1];
            gamePads[1] = GamePad.GetState(PlayerIndex.Two);
            gamePads[6] = gamePads[2];
            gamePads[2] = GamePad.GetState(PlayerIndex.Three);
            gamePads[7] = gamePads[3];
            gamePads[3] = GamePad.GetState(PlayerIndex.Four);

            base.Update(gameTime);
        }

        /// <summary>
        /// Checks is key is down
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public bool keyDown(Keys key)
        {
            return latestKeyboardState.IsKeyDown(key);
        }

        /// <summary>
        /// Checks is key is up
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public bool keyUp(Keys key)
        {
            return latestKeyboardState.IsKeyUp(key);
        }

        /// <summary>
        /// Checks if key has been pressed since last update
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public bool keyPressed(Keys key)
        {
            return latestKeyboardState.IsKeyDown(key) && oldestKeyboardState.IsKeyUp(key);
        }

        /// <summary>
        /// Checks if key has been released since last update
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public bool keyReleased(Keys key)
        {
            return latestKeyboardState.IsKeyUp(key) && oldestKeyboardState.IsKeyDown(key);
        }

        /// <summary>
        /// Checks if key has been held since last update
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public bool keyHeld(Keys key)
        {
            return latestKeyboardState.IsKeyDown(key) && oldestKeyboardState.IsKeyDown(key);
        }

        /// <summary>
        /// Checks is the button on the gamePad is down
        /// </summary>
        /// <param name="gamePad"></param>
        /// <param name="button"></param>
        /// <returns></returns>
        public bool buttonDown(int gamePad, Buttons button)
        {
            return gamePads[gamePad - 1].IsButtonDown(button);
        }

        /// <summary>
        /// Checks if the button on the gamePad is up
        /// </summary>
        /// <param name="gamePad"></param>
        /// <param name="button"></param>
        /// <returns></returns>
        public bool buttonUp(int gamePad, Buttons button)
        {
            return gamePads[gamePad - 1].IsButtonUp(button);
        }

        /// <summary>
        /// Checks if the button on the gamePad has been pressed since last update
        /// </summary>
        /// <param name="gamePad"></param>
        /// <param name="button"></param>
        /// <returns></returns>
        public bool buttonPressed(int gamePad, Buttons button)
        {
            return gamePads[gamePad - 1].IsButtonDown(button) && gamePads[gamePad + 3].IsButtonUp(button);
        }

        /// <summary>
        /// Checks if the button on the gamePad has been released since last update
        /// </summary>
        /// <param name="gamePad"></param>
        /// <param name="button"></param>
        /// <returns></returns>
        public bool buttonReleased(int gamePad, Buttons button)
        {
            return gamePads[gamePad - 1].IsButtonUp(button) && gamePads[gamePad + 3].IsButtonDown(button);
        }

        /// <summary>
        /// Checks if the button on the gamePad has been held since last update
        /// </summary>
        /// <param name="gamePad"></param>
        /// <param name="button"></param>
        /// <returns></returns>
        public bool buttonHeld(int gamePad, Buttons button)
        {
            return gamePads[gamePad - 1].IsButtonDown(button) && gamePads[gamePad + 3].IsButtonDown(button);
        }

        /// <summary>
        /// Returns a vector2 containing the X and Y positions of the left thumbstick on gamePad
        /// </summary>
        /// <param name="gamePad"></param>
        /// <returns></returns>
        public Vector2 leftThumbstick(int gamePad)
        {
            return gamePads[gamePad - 1].ThumbSticks.Left;
        }

        /// <summary>
        /// Returns a vector2 containing the X and Y positions of the right thumbstick on gamePad
        /// </summary>
        /// <param name="gamePad"></param>
        /// <returns></returns>
        public Vector2 rightThumbstick(int gamePad)
        {
            return gamePads[gamePad - 1].ThumbSticks.Right;
        }

        /// <summary>
        /// Returns a float with the value of the right trigger on gamePad
        /// </summary>
        /// <param name="gamePad"></param>
        /// <returns></returns>
        public float rightTrigger(int gamePad)
        {
            return gamePads[gamePad - 1].Triggers.Right;
        }

        /// <summary>
        /// Returns a float with the value of the left trigger on gamePad
        /// </summary>
        /// <param name="gamePad"></param>
        /// <returns></returns>
        public float leftTrigger(int gamePad)
        {
            return gamePads[gamePad - 1].Triggers.Left;
        }
    }
}

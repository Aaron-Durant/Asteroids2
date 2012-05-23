using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Uba_Engine;

namespace Asteroids_2
{
    class Input
    {
        public static void checkInput(Game1 g)
        {
            //Check for exit
            InputManager inputM = g.inputM;
            if (inputM.keyPressed(Keys.Escape) || inputM.buttonPressed(1, Buttons.Back)) g.engine.Exit();

            switch (g.gameState)
            {
                case GameState.initializing:
                    if (g.setupM.setupComplete)
                    {
                        for (int i = 1; i < 5; i++)
                        {
                            if (inputM.buttonPressed(i, Buttons.A) || inputM.buttonPressed(i, Buttons.Start))
                            {
                                g.engine.newState = g.mainMenu;
                                g.MasterController = i;
                            }
                        }
                        if (inputM.keyPressed(Keys.Enter))
                            g.engine.newState = g.mainMenu;
                    }
                    break;
                case GameState.title:
                    if (inputM.keyDown(Keys.Right) || inputM.buttonDown(1, Buttons.LeftThumbstickRight)) g.s.velocity.X += 5;
                    else if (inputM.keyDown(Keys.Left) || inputM.buttonDown(1, Buttons.LeftThumbstickLeft)) g.s.velocity.X += -5;
                    //else g.s.velocity.X = 0;
                    if (inputM.keyDown(Keys.Up) || inputM.buttonDown(1, Buttons.LeftThumbstickUp)) g.s.velocity.Y += -5;
                    else if (inputM.keyDown(Keys.Down) || inputM.buttonDown(1, Buttons.LeftThumbstickDown)) g.s.velocity.Y += 5;
                    //else g.s.velocity.Y = 0;

                    if (inputM.buttonPressed(1, Buttons.A))
                    {
                        g.s.position = new Vector2();
                        g.s.velocity = new Vector2();
                    }
                    break;
            }
        }
    }
}

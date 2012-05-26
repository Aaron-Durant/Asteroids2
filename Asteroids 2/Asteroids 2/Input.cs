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
            if (inputM.KeyPressed(Keys.Escape) || inputM.ButtonPressed(1, Buttons.Back)) g.engine.Exit();

            switch (g.gameState)
            {
                case GameState.Initializing:
                    if (g.setupM.SetupComplete)
                    {
                        for (int i = 1; i < 5; i++)
                        {
                            if (inputM.ButtonPressed(i, Buttons.A) || inputM.ButtonPressed(i, Buttons.Start))
                            {
                                g.engine.NewState = g.mainMenu;
                                g.MasterController = i;
                            }
                        }
                        if (inputM.KeyPressed(Keys.Enter))
                            g.engine.NewState = g.mainMenu;
                    }
                    break;
                case GameState.Title:
                    //if (inputM.keyDown(Keys.Right) || inputM.buttonDown(1, Buttons.LeftThumbstickRight)) g.s.velocity.X += 5;
                    //else if (inputM.keyDown(Keys.Left) || inputM.buttonDown(1, Buttons.LeftThumbstickLeft)) g.s.velocity.X += -5;
                    ////else g.s.velocity.X = 0;
                    //if (inputM.keyDown(Keys.Up) || inputM.buttonDown(1, Buttons.LeftThumbstickUp)) g.s.velocity += RotationHelper.VelocityAtAngle(5, g.s);
                    //else if (inputM.keyDown(Keys.Down) || inputM.buttonDown(1, Buttons.LeftThumbstickDown)) g.s.velocity.Y += 5;
                    ////else g.s.velocity.Y = 0;
                    

                    if (inputM.KeyPressed(Keys.Up)) Menus.mainMenu.PreviousMenuItem();
                    if (inputM.KeyPressed(Keys.Down)) Menus.mainMenu.NextMenuItem();

                    if (inputM.KeyDown(Keys.D))
                    {
                        g.s.Rotation += 0.1f;
                    }

                    if (inputM.ButtonDown(1, Buttons.A) || inputM.KeyPressed(Keys.A))
                    {
                        g.s.Rotation -= 0.1f;
                    }
                    break;
            }
        }
    }
}

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
                    //if (inputM.keyDown(Keys.Right) || inputM.buttonDown(1, Buttons.LeftThumbstickRight)) g.s.velocity.X += 5;
                    //else if (inputM.keyDown(Keys.Left) || inputM.buttonDown(1, Buttons.LeftThumbstickLeft)) g.s.velocity.X += -5;
                    ////else g.s.velocity.X = 0;
                    //if (inputM.keyDown(Keys.Up) || inputM.buttonDown(1, Buttons.LeftThumbstickUp)) g.s.velocity += RotationHelper.VelocityAtAngle(5, g.s);
                    //else if (inputM.keyDown(Keys.Down) || inputM.buttonDown(1, Buttons.LeftThumbstickDown)) g.s.velocity.Y += 5;
                    ////else g.s.velocity.Y = 0;
                    

                    if (inputM.keyPressed(Keys.Up)) Menus.mainMenu.PreviousMenuItem();
                    if (inputM.keyPressed(Keys.Down)) Menus.mainMenu.NextMenuItem();

                    if (inputM.keyDown(Keys.D))
                    {
                        g.s.Rotation += 0.1f;
                    }

                    if (inputM.buttonDown(1, Buttons.A) || inputM.keyPressed(Keys.A))
                    {
                        g.s.Rotation -= 0.1f;
                    }
                    break;
            }
        }
    }
}

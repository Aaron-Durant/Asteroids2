using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Uba_Engine;

namespace Asteroids_2
{
    public partial class Game1
    {
        public void checkInput()
        {
            //Check for exit
            if (inputM.KeyPressed(Keys.Escape) || inputM.ButtonPressed(1, Buttons.Back)) engine.Exit();

            switch (gameState)
            {
                case GameState.Initializing:
                    SetupInput();
                    break;
                case GameState.Menus:
                    TitleInput();
                    break;
            }
        }

        private  void SetupInput()
        {
            if (setupM.SetupComplete)
            {
                for (int i = 1; i < 5; i++)
                {
                    if (inputM.ButtonPressed(i, Buttons.A) || inputM.ButtonPressed(i, Buttons.Start))
                    {
                        engine.NewState = mainMenu;
                        MasterController = i;
                    }
                }
                if (inputM.KeyPressed(Keys.Enter))
                {
                    engine.NewState = mainMenu;
                }
            }
        }

        private void TitleInput()
        {
            if (inputM.KeyPressed(Keys.Up) || inputM.ButtonPressed(MasterController, Buttons.LeftThumbstickUp))
                menuM.CurrentMenu.PreviousMenuItem();
            if (inputM.KeyPressed(Keys.Down) || inputM.ButtonPressed(MasterController, Buttons.LeftThumbstickDown))
                menuM.CurrentMenu.NextMenuItem();
            if (inputM.KeyPressed(Keys.Back) || inputM.ButtonPressed(MasterController, Buttons.B))
                menuM.CurrentMenu.OnBack();
            if (inputM.KeyPressed(Keys.Enter) || inputM.ButtonPressed(MasterController, Buttons.A)) 
                menuM.CurrentMenu.MenuItems[menuM.CurrentMenu.SelectedItem].OnSelect();
        }
    }
}

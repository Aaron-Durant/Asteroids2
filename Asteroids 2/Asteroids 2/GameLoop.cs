using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;

using Uba_Engine;

namespace Asteroids_2
{
    public partial class Game1
    {
        public void gameLoop()
        {
            //Check input
            checkInput();

            switch (gameState)
            {
                case GameState.Loading:
                    loading();
                    break;
                case GameState.Initializing:
                    settingUp();
                    break;
                case GameState.Menus:
                    
                    break;

            }






           
        }
    }
}

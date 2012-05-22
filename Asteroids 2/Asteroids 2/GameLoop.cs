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
            Input.checkInput(this);

            switch (gameState)
            {
                case GameState.loading:
                    loading();
                    break;
                case GameState.initializing:
                    settingUp();
                    break;

            }






           
        }
    }
}

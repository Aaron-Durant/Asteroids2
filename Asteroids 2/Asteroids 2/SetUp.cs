﻿using System;
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
        /// <summary>
        /// Called when the gameState is changed to intialising
        /// </summary>
        public void setUp()
        {
            gameState = GameState.initializing;

            // Add setup tasks here

            setupM.start();
        }

        /// <summary>
        /// Called when the game state is setting up
        /// Will run until setUp is complete
        /// </summary>
        public void settingUp()
        {
            if (setupM.setupComplete)
            {
                engine.clearAllAssets();
                textM.AddText(new Text(GFX.sfTitle, "ASTEROIDS", new Vector2(screenSize.Center.X, screenSize.Center.Y), Color.White, Align.center));
            }
        }


    }
}

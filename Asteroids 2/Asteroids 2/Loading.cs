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
        public void loading()
        {
            if (loadM.AtLeastFirstLoaded)
            {
                loadM.CollectedFirst();
                GFX.txSplashScreen = (Texture2D)loadM.getLoadedAsset(0);
                StaticSprite splashSprite = new StaticSprite(new Vector2(0, 0));
                splashSprite.frame.define(GFX.txSplashScreen, new Rectangle(0, 0, 1280, 720));
                engine.AddStaticSprite(splashSprite);
            }

            if (loadM.loadComplete)
            {
                // copy loaded assets to texutes
                GFX.txSampleTexture = (Texture2D)loadM.getLoadedAsset(1); // Get Asset 1

                // copy loaded assets to fonts
                GFX.sfDebug = (SpriteFont) loadM.getLoadedAsset(2); // Get Asset 2
                GFX.sfTitle = (SpriteFont) loadM.getLoadedAsset(3); // Get Asset 3

                //change to new state
                engine.newState = setUp;
            }


            

        }

        
    }
}

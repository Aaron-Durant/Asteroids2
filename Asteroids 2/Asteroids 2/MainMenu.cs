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
        public Sprite s;
        public int MasterController = 1;


        public void mainMenu()
        {
            engine.clearAllAssets();
            gameState = GameState.title;

            s = new Sprite();
            engine.addSprite(s);
            s.frame.define(GFX.txSampleTexture, new Rectangle(0, 15, 642, 558));
            Limit.limitInitialize(s, Limit.wrap, screenSize);
        }
    }
}

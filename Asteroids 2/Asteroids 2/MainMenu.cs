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
            s.frame.Define(GFX.txSampleTexture, new Rectangle(0, 15, 642, 558));
            s.frame.Define(GFX.txSampleTexture, new Rectangle(643, 25, 637, 558));
            s.InitialiseAnimator();
            s.frame.Animator.AnimateByDistance(25);
            s.Rotation = 1f;
            Limit.limitInitialize(s, Limit.wrap, screenSize);
        }
    }
}

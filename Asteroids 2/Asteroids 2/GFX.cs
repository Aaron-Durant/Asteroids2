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
    /// <summary>
    /// Holds all loaded assets
    /// </summary>
    public class GFX
    {
        // Textures
        public static Texture2D txSampleTexture;
        public static Texture2D txSplashScreen;

        //SpriteFonts
        public static SpriteFont sfDebug;
        public static SpriteFont sfTitle;
        public static SpriteFont sfMenu;
    }
}

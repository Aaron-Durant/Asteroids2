using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;

using Uba_Engine;

namespace Asteroids_2
{
    public class Menus
    {
        // Menus
        public static Menu mainMenu;

        public static void SelectText(Text t)
        {
            t.TextColor = Color.Red;
        }

        public static void DeselectText(Text t)
        {
            t.TextColor = Color.White;
        }


    }

    
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using System.Xml.Serialization;
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
        public static Menu MainMenu;
        public static Menu SinglePlayerMenu;
        public static Menu MultiPlayerMenu;
        public static Menu OptionsMenu;
        public static Menu PauseMenu;

        public static void SelectText(Text t)
        {
            t.TextColor = Color.Red;
            t.Scale = new Vector2(0.75f);
        }

        public static void DeselectText(Text t)
        {
            t.TextColor = Color.White;
            t.Scale = new Vector2(0.5f);
        }

        public static void ReadMenu(Reader reader, Object menu)
        {
            if (reader.ReadPossible)
            {
                reader.Serializer = new XmlSerializer(typeof(Menu));
                menu = (Menu)reader.Serializer.Deserialize(reader.sr);
                reader.sr.Close();
            }
        }

    }

    
}

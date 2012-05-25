using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace Uba_Engine
{
    public class Menu
    {

        public int TotalItems;
        public int SelectedItem;
        public string SelectedName { get { return MenuItems[SelectedItem].text; } }

        public List<Text> MenuItems;

        public SpriteFont Font;
        public Color MenuColor;
        public Align Alignment;
        public Vector2 Scale;

        public Vector2 StartPosition;
        internal int Spacing;

        public bool Visible;
        public bool VerticalMenu;
        public bool WrapAtEnd;

        public MenuItemSelect OnSelect = DefaultOnSelect;
        
        public MenuItemSelect OnDeselect = DefaultOnSelect;

        public Menu(Vector2 position, int spacing, bool isVerticle, SpriteFont font, Color menuColor, Vector2 scale, Align alignment)
        {
            MenuItems = new List<Text>();
            StartPosition = position;
            Spacing = spacing;
            VerticalMenu = isVerticle;
            Font = font;
            MenuColor = menuColor;
            Alignment = alignment;
            Scale = scale;
        }

        public void AddMenuItem(Text t)
        {
            t.TextColor = MenuColor;
            t.Font = Font;
            t.Alignment = Alignment;
            t.Scale = Scale;
            if (MenuItems.Count == 0) OnSelect(t);
            MenuItems.Add(t);
            TotalItems++;
        }

        public void NextMenuItem()
        {
            if (SelectedItem == TotalItems - 1)
            {
                if (WrapAtEnd)
                {
                    OnDeselect(MenuItems[SelectedItem]);
                    SelectedItem = 0;
                    OnSelect(MenuItems[SelectedItem]);
                }
            }
            else
            {
                OnDeselect(MenuItems[SelectedItem]);
                SelectedItem++;
                OnSelect(MenuItems[SelectedItem]);
            }
        }

        public void PreviousMenuItem()
        {
            if (SelectedItem == 0)
            {
                if (WrapAtEnd)
                {
                    OnDeselect(MenuItems[SelectedItem]);
                    SelectedItem = TotalItems - 1;
                    OnSelect(MenuItems[SelectedItem]);
                }
            }
            else
            {
                OnDeselect(MenuItems[SelectedItem]);
                SelectedItem--;
                OnSelect(MenuItems[SelectedItem]);
            }
        }

        private static void DefaultOnSelect(Text t)
        {
        }

    }
}

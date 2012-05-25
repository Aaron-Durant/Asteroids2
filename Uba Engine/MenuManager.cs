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
    public class MenuManager : DrawableGameComponent
    {

        public List<Menu> Menus;
        private TextManager TextM;

        public MenuManager(Game g, TextManager textM) : base (g)
        {
            Menus = new List<Menu>();
            TextM = textM;
        }

        public override void Update(GameTime gameTime)
        {
            foreach (Menu menu in Menus)
            {
                if (menu.Visible)
                {
                    for (int i = 0; i < menu.TotalItems; i++)
                    {
                        Text menuItem = menu.MenuItems[i];
                        if (menu.VerticalMenu)
                            menuItem.Position = menu.StartPosition + new Vector2(0, menu.Spacing * i);
                        else 
                            menuItem.Position = menu.StartPosition + new Vector2(menu.Spacing * i, 0);
                        TextM.AddText(menuItem);
                    }
                }
            }
            base.Update(gameTime);
        }

        public void AddMenu(Menu m)
        {
            Menus.Add(m);
        }

        public void ShowMenu(Menu m)
        {
            m.Visible = true;
        }

        public void HideMenu(Menu m)
        {
            m.Visible = false;
        }

    }
}

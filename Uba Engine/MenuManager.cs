using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace Uba_Engine
{
    public class MenuManager : DrawableGameComponent
    {
        /// <summary>
        /// Menus the MenuManager is managing and TextManager used to draw Menus
        /// </summary>
        public List<Menu> Menus;
        private TextManager textM;

        /// <summary>
        /// Creates a new MenuManager
        /// </summary>
        /// <param name="g"> The Game object associated with the MenuManager </param>
        /// <param name="textM"> The TextManager used to draw the Menus</param>
        public MenuManager(Game g, TextManager textM) : base (g)
        {
            Menus = new List<Menu>();
            this.textM = textM;
        }

        /// <summary>
        /// Updates all visible menus and adds them to textM for drawing
        /// </summary>
        /// <param name="gameTime"> The GameTime object holding timing data </param>
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
                        textM.AddText(menuItem);
                    }
                }
            }
            base.Update(gameTime);
        }

        /// <summary>
        /// Adds m to the list of Menus being managed
        /// </summary>
        /// <param name="m"> The Menu to add to Menus </param>
        public void AddMenu(Menu m)
        {
            Menus.Add(m);
        }

        /// <summary>
        /// Makes the Menu visible
        /// </summary>
        /// <param name="m"> The Menu to make visible </param>
        public void ShowMenu(Menu m)
        {
            m.Visible = true;
        }

        /// <summary>
        /// Makes the Menu invisible
        /// </summary>
        /// <param name="m"> The Menu to make invisible </param>
        public void HideMenu(Menu m)
        {
            m.Visible = false;
        }

        /// <summary>
        /// Makes all menus being managed invisible
        /// </summary>
        public void HideAllMenus()
        {
            foreach (Menu menu in Menus)
            {
                menu.Visible = false;
            }
        }

    }
}

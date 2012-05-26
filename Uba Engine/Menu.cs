using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Uba_Engine
{
    public class Menu
    {
        /// <summary>
        /// The total number of items in the menu, the currently selected item and the String associated with that item
        /// </summary>
        public int TotalItems;
        public int SelectedItem;
        public string SelectedName { get { return MenuItems[SelectedItem].text; } }

        /// <summary>
        /// The list of all Text objects in the Menu
        /// </summary>
        public List<Text> MenuItems;

        /// <summary>
        /// Properties for text formatting in the menu
        /// </summary>
        public SpriteFont Font;
        public Color MenuColor;
        public Align Alignment;
        public Vector2 Scale;

        /// <summary>
        /// Start position of the Menu and the Spacing between each item
        /// </summary>
        public Vector2 StartPosition;
        internal int Spacing;

        /// <summary>
        /// Is the Menu visible? Is the Menu verticle or horizontal? Should NextMenuItem() return to first item when on last?
        /// </summary>
        public bool Visible;
        public bool VerticalMenu;
        public bool WrapAtEnd;

        /// <summary>
        /// Delegates to be called on a MenuItem (Text object) when it becomes selected and deselected
        /// </summary>
        public MenuItemSelect OnSelect = DefaultOnSelect;
        public MenuItemSelect OnDeselect = DefaultOnSelect;

        /// <summary>
        /// Creates a new Menu Object
        /// </summary>
        /// <param name="position"> The postion of the first item in the menu </param>
        /// <param name="spacing"> The spacing betweeen each item in the menu </param>
        /// <param name="isVerticle"> Set to true for Verticle menu, false for Horizontal menu </param>
        /// <param name="font"> The font to be used in the menu </param>
        /// <param name="menuColor"> The default color of the menu items </param>
        /// <param name="scale"> The default scale of the menu items </param>
        /// <param name="alignment"> The alignment of items in the menu </param>
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

        /// <summary>
        /// Adds a new Text object to MenuItems and sets its properties. Selects it if it is first item added to the menu
        /// </summary>
        /// <param name="t"> The Text object to add to the Menu </param>
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

        /// <summary>
        /// Selects the next item in the menu. If at end of menu select the first item if WrapAtEnd is true, else does nothing
        /// </summary>
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

        /// <summary>
        /// Selects the previous item in the menu. If at start of menu select the last item if WrapAtEnd is true, else does nothing
        /// </summary>
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

        /// <summary>
        /// The default Delegate run when a menu Item is selected. Does nothing. Here to keep code happy
        /// </summary>
        /// <param name="t"> The Text object to do nothing to </param>
        private static void DefaultOnSelect(Text t) { }

    }
}

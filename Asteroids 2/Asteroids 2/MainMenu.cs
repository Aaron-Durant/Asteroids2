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
        public int MasterController = 1;


        public void mainMenu()
        {
            engine.ClearAllAssets();
            gameState = GameState.Menus;
            if (!Guide.IsVisible)
            fileM.GetStorageDevice();
            menuM.CurrentMenu = Menus.MainMenu;
            menuM.ShowMenu(Menus.MainMenu, true);
        }

        public void CreateMainMenu()
        {
            Menu menu = new Menu(new Vector2(200), 75, true, GFX.sfTitle, Color.White, new Vector2(0.5f), Align.Left, MainMenuBack);
            menu.OnSelect = Menus.SelectText;
            menu.OnDeselect = Menus.DeselectText;
            menu.AddMenuItem(new Text("Single Player", SinglePlayer));
            menu.AddMenuItem(new Text("Multiplayer", Multiplayer));
            menu.AddMenuItem(new Text("Options", Options));
            menu.AddMenuItem(new Text("Exit", engine.Exit));
            Menus.MainMenu = menu;
            menuM.AddMenu(Menus.MainMenu);
        }
        
        public void MainMenuBack()
        {
            engine.NewState = setUp;
        }

        public void SinglePlayer()
        {
            fileM.AddFileOperation(new FileAsset("Hello.xml", XMLMethod.writeXML, 5));
            //menuM.HideMenu(Menus.MainMenu);
            //menuM.CurrentMenu = Menus.SinglePlayerMenu;
            //menuM.ShowMenu(Menus.SinglePlayerMenu, true);
        }

        public void Multiplayer()
        {
            menuM.HideMenu(Menus.MainMenu);
            menuM.CurrentMenu = Menus.MultiPlayerMenu;
            menuM.ShowMenu(Menus.MultiPlayerMenu, true);
        }

        public void Options()
        {
            menuM.HideMenu(Menus.MainMenu);
            menuM.CurrentMenu = Menus.OptionsMenu;
            menuM.ShowMenu(Menus.OptionsMenu, true);
        }

        public void CreateSinglePlayerMenu()
        {
            Menu menu = new Menu(new Vector2(200), 75, true, GFX.sfTitle, Color.White, new Vector2(0.5f), Align.Left, SinglePlayerBack);
            menu.OnSelect = Menus.SelectText;
            menu.OnDeselect = Menus.DeselectText;
            menu.AddMenuItem(new Text("Campaign", Campaign));
            menu.AddMenuItem(new Text("Classic", Classic));
            Menus.SinglePlayerMenu = menu;
            menuM.AddMenu(Menus.SinglePlayerMenu);
        }

        public void SinglePlayerBack()
        {
            menuM.HideMenu(Menus.SinglePlayerMenu);
            menuM.CurrentMenu = Menus.MainMenu;
            menuM.ShowMenu(Menus.MainMenu, false);
        }

        public void Campaign()
        {
        }

        public void Classic()
        {
        }

        public void CreateMultiPlayerMenu()
        {
            Menu menu = new Menu(new Vector2(200), 75, true, GFX.sfTitle, Color.White, new Vector2(0.5f), Align.Left, MultiPlayerBack);
            menu.OnSelect = Menus.SelectText;
            menu.OnDeselect = Menus.DeselectText;
            menu.AddMenuItem(new Text("Co-op", Coop));
            menu.AddMenuItem(new Text("Player v Player", PVP));
            Menus.MultiPlayerMenu = menu;
            menuM.AddMenu(Menus.MultiPlayerMenu);
        }

        public void MultiPlayerBack()
        {
            menuM.HideMenu(Menus.MultiPlayerMenu);
            menuM.CurrentMenu = Menus.MainMenu;
            menuM.ShowMenu(Menus.MainMenu, false);
        }

        public void PVP()
        {
        }

        public void Coop()
        {
        }

        public void CreateOptionMenu()
        {
            Menu menu = new Menu(new Vector2(200), 75, true, GFX.sfTitle, Color.White, new Vector2(0.5f), Align.Left, OptionBack);
            menu.OnSelect = Menus.SelectText;
            menu.OnDeselect = Menus.DeselectText;
            menu.AddMenuItem(new Text("Graphics", Graphics));
            Menus.OptionsMenu = menu;
            menuM.AddMenu(Menus.OptionsMenu);
        }

        public void OptionBack()
        {
            menuM.HideMenu(Menus.OptionsMenu);
            menuM.CurrentMenu = Menus.MainMenu;
            menuM.ShowMenu(Menus.MainMenu, false);
        }

        public void Graphics()
        {
            
        }

    }

}

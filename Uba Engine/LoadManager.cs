using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace Uba_Engine
{
    public class LoadManager : DrawableGameComponent
    {
        /// <summary>
        /// Is the load completed
        /// </summary>
        public bool loadComplete = false;
        /// <summary>
        /// Has the first asset been loaded
        /// </summary>
        internal bool firstAsset = false;
        public bool AtLeastFirstLoaded
        {
            get { return loadedAssets > 0 && !firstAsset; }
        }
        public void CollectedFirst()
        {
            firstAsset = true;
        }
        /// <summary>
        /// Holds a list of assets to be loaded
        /// </summary>
        List<Asset> pendingList = new List<Asset>();
        /// <summary>
        /// Holds a list of assests that have been loaded
        /// </summary>
        List<Asset> loadedList = new List<Asset>();
        /// <summary>
        /// Holds the number of assets that have been loaded
        /// </summary>
        public int loadedAssets = 0;
        /// <summary>
        /// The time to pause between loading each asset
        /// </summary>
        int pause;
        /// <summary>
        /// Holds the game object the manager belongs to
        /// </summary>
        Game game;
        

        public LoadManager(Game g) : base(g)
        {
            game = g;
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        /// <summary>
        /// Adds the texure at filename to the list of assets to be loaded
        /// </summary>
        /// <param name="filename"></param>
        public void addTexture(string filename)
        {
            pendingList.Add(new Asset(filename, typeof(Texture2D)));
        }

        public void addFont(string fontName)
        {
            pendingList.Add(new Asset(fontName, typeof(SpriteFont)));
        }

        public object getLoadedAsset(int asset)
        {
            return loadedList[asset].loadedObject;
        }

        /// <summary>
        /// Starts the loadManager in a new thread, so the game can do something else while waiting
        /// </summary>
        /// <param name="pause">Time to wait in milliseconds between each asset being loaded</param>
        public void start(int pause)
        {
            loadedAssets = 0;
            this.pause = pause;
            new Thread((ThreadStart)(() => loadAssets()))
            {

            }.Start();

        }

        private void loadAssets()
        {
            while (loadedAssets < pendingList.Count)
            {
                loadNextAsset();
                Thread.Sleep(pause);
            }
            Thread.Sleep(pause);
            pendingList.Clear();
            loadComplete = true;
        }

        private void loadNextAsset()
        {
            if (pendingList[loadedAssets].type == typeof(Texture2D))
            {
                try
                {
                    pendingList[loadedAssets].loadedObject = game.Content.Load<Texture2D>(pendingList[loadedAssets].filename);
                    pendingList[loadedAssets].loadStatus = "loaded";
                    loadedList.Add(pendingList[loadedAssets]);
                }
                catch 
                {
                    Console.WriteLine("Error: file not found");
                }
            }
            if (pendingList[loadedAssets].type == typeof(SpriteFont))
            {
                try
                {
                    pendingList[loadedAssets].loadedObject = game.Content.Load<SpriteFont>(pendingList[loadedAssets].filename);
                    pendingList[loadedAssets].loadStatus = "loaded";
                    loadedList.Add(pendingList[loadedAssets]);
                }
                catch (Exception)
                {
                    Console.WriteLine("Error: font not found");
                }
            }
            loadedAssets++;
        }

    }
}

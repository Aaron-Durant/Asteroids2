using System;
using System.Collections.Generic;
using System.Threading;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Uba_Engine
{
    public class LoadManager : DrawableGameComponent
    {
        /// <summary>
        /// Is the load completed
        /// </summary>
        public bool LoadComplete = false;
        /// <summary>
        /// Has the first asset been loaded
        /// </summary>
        internal bool FirstAsset = false;
        /// <summary>
        /// Returns true if the FirstAsset has been loaded and it has not returned true before;
        /// </summary>
        public bool AtLeastFirstLoaded
        {
            get { return LoadedAssets > 0 && !FirstAsset; }
        }
        /// <summary>
        /// Sets FirstAsset to true so that AtLeastFirstLoaded will return false for all future calls
        /// </summary>
        public void CollectedFirst()
        {
            FirstAsset = true;
        }
        /// <summary>
        /// Holds a list of assets to be loaded
        /// </summary>
        List<Asset> _pendingList = new List<Asset>();
        /// <summary>
        /// Holds a list of assests that have been loaded
        /// </summary>
        List<Asset> _loadedList = new List<Asset>();
        /// <summary>
        /// Holds the number of assets that have been loaded
        /// </summary>
        public int LoadedAssets;
        /// <summary>
        /// The time to pause between loading each asset
        /// </summary>
        int _pause;
        /// <summary>
        /// Holds the game object the manager belongs to
        /// </summary>
        Game game;
        
        /// <summary>
        /// Creates a new LoadManager
        /// </summary>
        /// <param name="g"> The Game object associated with the LoadManager </param>
        public LoadManager(Game g) : base(g)
        {
            game = g;
        }

        /// <summary>
        /// Adds the texure at filename to the list of Assets to be loaded
        /// </summary>
        /// <param name="filename"> The file where the texture can be found</param>
        public void AddTexture(string filename)
        {
            _pendingList.Add(new Asset(filename, typeof(Texture2D)));
        }

        /// <summary>
        /// Adds the font at the filename to the list of Assets to be loaded
        /// </summary>
        /// <param name="fontName"> The file where the font can be found </param>
        public void AddFont(string fontName)
        {
            _pendingList.Add(new Asset(fontName, typeof(SpriteFont)));
        }

        /// <summary>
        /// Returns an object containing a loaded Asset from _loadedList
        /// </summary>
        /// <param name="asset"> The position of the Asses in _loadedList </param>
        /// <returns></returns>
        public object GetLoadedAsset(int asset)
        {
            return _loadedList[asset].LoadedObject;
        }

        /// <summary>
        /// Starts the loadManager in a new thread, so the game can do something else while waiting
        /// </summary>
        /// <param name="pause">Time to wait in milliseconds between each asset being loaded</param>
        public void Start(int pause)
        {
            LoadedAssets = 0;
            _pause = pause;
            new Thread((ThreadStart)(() => LoadAssets()))
            {

            }.Start();

        }

        /// <summary>
        /// Starts the loadManager in a new thread, so the game can do something else while waiting
        /// </summary>
        /// <param name="targetLoadTime"> The target time in milliseconds to load all the Assets</param>
        public void Start(float targetLoadTime)
        {
            LoadedAssets = 0;
            _pause = (int)(targetLoadTime/_pendingList.Count);
            new Thread((ThreadStart)(() => LoadAssets()))
            {

            }.Start();
        }

        /// <summary>
        /// Loads the Assets in _pendingList, sleeping for a set time between each load
        /// </summary>
        private void LoadAssets()
        {
            while (LoadedAssets < _pendingList.Count)
            {
                LoadNextAsset();
                Thread.Sleep(_pause);
            }
            Thread.Sleep(_pause);
            _pendingList.Clear();
            LoadComplete = true;
        }

        /// <summary>
        /// Loads the next pending Asset from _pendingList and puts the loaded object into _loadedList
        /// </summary>
        private void LoadNextAsset()
        {
            if (_pendingList[LoadedAssets].Type == typeof(Texture2D))
            {
                try
                {
                    _pendingList[LoadedAssets].LoadedObject = game.Content.Load<Texture2D>(_pendingList[LoadedAssets].Filename);
                    _pendingList[LoadedAssets].LoadStatus = "loaded";
                    _loadedList.Add(_pendingList[LoadedAssets]);
                }
                catch 
                {
                    Console.WriteLine("Error: file not found");
                }
            }
            if (_pendingList[LoadedAssets].Type == typeof(SpriteFont))
            {
                try
                {
                    _pendingList[LoadedAssets].LoadedObject = game.Content.Load<SpriteFont>(_pendingList[LoadedAssets].Filename);
                    _pendingList[LoadedAssets].LoadStatus = "loaded";
                    _loadedList.Add(_pendingList[LoadedAssets]);
                }
                catch (Exception)
                {
                    Console.WriteLine("Error: font not found");
                }
            }
            LoadedAssets++;
        }

    }
}

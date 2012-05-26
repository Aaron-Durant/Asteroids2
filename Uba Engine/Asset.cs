using System;

namespace Uba_Engine
{
    class Asset
    {
        /// <summary>
        /// The filename where the asset is stored
        /// </summary>
        internal string Filename = "";
        /// <summary>
        /// The type of the asset
        /// </summary>
        internal Type Type;
        /// <summary>
        /// The loaded object of the asset
        /// </summary>
        internal object LoadedObject;
        /// <summary>
        /// The assets loaded status
        /// </summary>
        internal string LoadStatus = "notLoaded";

        /// <summary>
        /// Constructor for the Asset
        /// </summary>
        /// <param name="filename"> The file where the Asset can be found </param>
        /// <param name="type"> The object type of the Asset </param>
        internal Asset(string filename, Type type)
        {
            Filename = filename;
            Type = type;
        }
    }
}

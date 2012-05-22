using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Uba_Engine
{
    class Asset
    {
        /// <summary>
        /// The filename where the asset is stored
        /// </summary>
        internal string filename = "";
        /// <summary>
        /// The type of the asset
        /// </summary>
        internal Type type = null;
        /// <summary>
        /// The loaded object of the asset
        /// </summary>
        internal object loadedObject;
        /// <summary>
        /// The assets loaded status
        /// </summary>
        internal string loadStatus = "notLoaded";

        internal Asset(string filename, Type type)
        {
            this.filename = filename;
            this.type = type;
        }
    }
}

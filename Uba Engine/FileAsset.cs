using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Uba_Engine
{
    public class FileAsset
    {
        /// <summary>
        /// The filename to read or write from
        /// This is relative from the FileManagers root directory
        /// </summary>
        internal String Filename = "";
        /// <summary>
        /// Holds the object that has been loaded from the file or to be saved
        /// </summary>
        internal Object Object;
        /// <summary>
        /// Should the FileManager read or write?
        /// </summary>
        internal XMLMethod Method;
        /// <summary>
        /// The method to use to read the file
        /// </summary>
        internal ReadDelegate ReadMethod;

        public FileAsset(String filename, XMLMethod method, Object obj)
        {
            Filename = filename;
            Object = obj;
            Method = method;
        }

        public FileAsset(String filename, XMLMethod method, object obj, ReadDelegate readDelegate)
        {
            Filename = filename;
            Method = method;
            Object = obj;
            ReadMethod = readDelegate;
        }
    }

    public enum XMLMethod
    {
        readXML,
        writeXML
    }
}

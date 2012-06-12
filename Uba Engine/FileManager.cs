using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Storage;

namespace Uba_Engine
{
    public class FileManager
    {
        /// <summary>
        /// A List of files still to be loaded or saved
        /// </summary>
        List<FileAsset> pendingOperations;
        /// <summary>
        /// The root directory of the FileManager
        /// </summary>
        String Root;
        /// <summary>
        /// The storage device used to save the file
        /// </summary>
        StorageDevice storageDevice;
        /// <summary>
        /// The location on the HDD to store files
        /// </summary>
        StorageContainer storageContainer;
        /// <summary>
        /// The xml serializer for use
        /// </summary>
        XmlSerializer Serializer;
        

        public FileManager(String rootDirectory)
        {
            Root = rootDirectory;
            pendingOperations = new List<FileAsset>();
        }

        public void AddFileOperation(FileAsset fileAsset)
        {
            pendingOperations.Add(fileAsset);
            NextOperation();
        }

        public void GetStorageDevice()
        {
            if (!Guide.IsVisible)
            {
                storageDevice = null;
                StorageDevice.BeginShowSelector(PlayerIndex.One, SetStorage, (Object)"Get StorageDevice");
            }
        }

        private void SetStorage(IAsyncResult result)
        {
            storageDevice = StorageDevice.EndShowSelector(result);
        }

        private void NextOperation()
        {
            if (pendingOperations.Count > 0)
            {
                switch (pendingOperations[0].Method)
                {
                    case XMLMethod.readXML:
                        ReadFromFile();
                        break;
                    case XMLMethod.writeXML:
                        WriteToFile();
                        break;
                }
            }
        }

        private void ReadFromFile()
        {
            if (storageDevice.IsConnected) storageDevice.BeginOpenContainer(Root, Load, (Object)"Reading From File");
        }

        private void WriteToFile()
        {
            if (storageDevice.IsConnected) storageDevice.BeginOpenContainer(Root, Save, (Object)"Writing To File");
        }

        private void Load(IAsyncResult ar)
        {


            pendingOperations.RemoveAt(0);
            NextOperation();
        }


        private void Save(IAsyncResult ar)
        {
            storageContainer = storageDevice.EndOpenContainer(ar);
            if (storageContainer != null)
            {
                StreamWriter sw = new StreamWriter(storageContainer.CreateFile(pendingOperations[0].Filename));
                Serializer = new XmlSerializer(pendingOperations[0].Object.GetType());
                Serializer.Serialize(sw, pendingOperations[0].Object);
                sw.Close();
                storageContainer.Dispose();
            }

            pendingOperations.RemoveAt(0);
            NextOperation();
        }
    }
}

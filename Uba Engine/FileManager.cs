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
    public class Reader
    {
        /// <summary>
        /// The location on the HDD to store files
        /// </summary>
        public StorageContainer storageContainer;
        /// <summary>
        /// The xml serializer for use
        /// </summary>
        public XmlSerializer Serializer;
        /// <summary>
        /// Is it possible to read from the file?
        /// </summary>
        public bool ReadPossible;
        /// <summary>
        /// The stream to read from
        /// </summary>
        public StreamReader sr;

        public Reader(StorageContainer sc)
        {
            storageContainer = sc;
        }
    }

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
            if (!Guide.IsVisible && storageDevice == null)
            {
                StorageDevice.BeginShowSelector(SetStorage, (Object)"Get StorageDevice");
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

            Reader reader = new Reader(storageDevice.EndOpenContainer(ar));
            if (reader.storageContainer != null && reader.storageContainer.FileExists(pendingOperations[0].Filename))
            {
                reader.sr = new StreamReader(reader.storageContainer.OpenFile(pendingOperations[0].Filename, FileMode.Open, FileAccess.Read));
                reader.ReadPossible = true;
            }

            pendingOperations[0].ReadMethod(reader, pendingOperations[0].Object);
            

            pendingOperations.RemoveAt(0);
            NextOperation();
        }


        private void Save(IAsyncResult ar)
        {
            StorageContainer storageContainer = storageDevice.EndOpenContainer(ar);
            if (storageContainer != null)
            {
                StreamWriter sw = new StreamWriter(storageContainer.CreateFile(pendingOperations[0].Filename));
                XmlSerializer Serializer = new XmlSerializer(pendingOperations[0].Object.GetType());
                Serializer.Serialize(sw, pendingOperations[0].Object);
                sw.Close();
                storageContainer.Dispose();
            }

            pendingOperations.RemoveAt(0);
            NextOperation();
        }

    }
}

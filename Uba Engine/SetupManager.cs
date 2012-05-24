using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Uba_Engine
{
    public class SetupManager
    {
        /// <summary>
        /// List of delagates to run when setting up
        /// </summary>
        public SetupDelegate onSetup;
        /// <summary>
        /// Is setup complete?
        /// </summary>
        public bool setupComplete = false;

        public SetupManager()
        {
            
        }


        /// <summary>
        /// Adds a new setupTask to onUpdate
        /// </summary>
        /// <param name="setupTask"></param>
        public void addSetupTask(SetupDelegate setupTask)
        {
            onSetup += setupTask;
        }

        /// <summary>
        /// Starts a new Thread to run setup tasks
        /// </summary>
        /// <param name="pause"></param>
        public void start()
        {
            new Thread((ThreadStart)(() => runSetupTasks()))
            {

            }.Start();
        }

        /// <summary>
        /// Runs all delegates held in onSetup;
        /// </summary>
        public void runSetupTasks()
        {
            if (onSetup != null) onSetup();
            setupComplete = true;
        }
    }
}

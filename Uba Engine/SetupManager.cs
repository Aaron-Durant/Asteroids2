using System.Threading;

namespace Uba_Engine
{
    public class SetupManager
    {
        /// <summary>
        /// List of delagates to run when setting up
        /// </summary>
        public SetupDelegate OnSetup;
        /// <summary>
        /// Is setup complete?
        /// </summary>
        public bool SetupComplete;

        public SetupManager()
        {
            
        }

        /// <summary>
        /// Adds a new setupTask to onUpdate
        /// </summary>
        /// <param name="setupTask"></param>
        public void AddSetupTask(SetupDelegate setupTask)
        {
            OnSetup += setupTask;
        }

        /// <summary>
        /// Starts a new Thread to run setup tasks
        /// </summary>
        public void Start()
        {
            new Thread((ThreadStart)(() => RunSetupTasks()))
            {

            }.Start();
        }

        /// <summary>
        /// Runs all delegates held in onSetup;
        /// </summary>
        public void RunSetupTasks()
        {
            if (OnSetup != null) OnSetup();
            SetupComplete = true;
        }
    }
}

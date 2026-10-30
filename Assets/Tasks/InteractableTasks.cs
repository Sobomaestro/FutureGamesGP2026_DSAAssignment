using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;


namespace Environment.Tasks
{
    [CreateAssetMenu(fileName = "InteractableTasks", menuName = "Scriptable Objects/InteractableTasks")]

    public class InteractableTasks : Task {
        [SerializeField] private string taskDescription = "Sort the list of employees to find the suspect, and save the world.";
        [SerializeField] public TextAsset jsonFile;
        [SerializeField] public playerTaskManager taskManager;
        [SerializeField] Task sortTask;
        private string textToPrint = "Beep boop, computer sounds, a thousand modems singing in unison far, far away";
        public override void Execute() 
        {
            
        }

    }

}
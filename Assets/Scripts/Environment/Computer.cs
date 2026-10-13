using Environment.Tasks;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Unity.VisualScripting;
using UnityEngine;

namespace Environment
{
    public class Computer : MonoBehaviour, IInteractable
    {
        [SerializeField] public DebugPrintTask debugTasks;
        [SerializeField] public playerTaskManager taskManager;
        [SerializeField] List<Task> listOfBullshit = new List<Task>();
        Stack<Task> taskList = new Stack<Task>();
        

        void Awake()
        {
     
        }


        public virtual void OnInteract()
        {
            if(listOfBullshit.Count > 0) {
                taskManager.TaskAdder(listOfBullshit[0]);
                listOfBullshit.RemoveAt(0);
            }
            else Debug.Log("No more tasks in need of being done, my liege");
               //Task testTask = taskList.Pop();
               //testTask.Execute();            
        }
    }
}

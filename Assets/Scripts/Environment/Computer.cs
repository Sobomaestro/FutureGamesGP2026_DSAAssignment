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
        [SerializeField] playerTaskManager playerTasks;
        [SerializeField] List<Task> listOfBullshit = new List<Task>();
        Stack<Task> taskList = new Stack<Task>();
        

        void Awake()
        {
     
        }


        public void OnInteract()
        {
            if(listOfBullshit.Count > 0) {
                playerTasks.TaskAdder(listOfBullshit[0]);
                listOfBullshit.RemoveAt(0);
            }
            else Debug.Log("No more tasks in need of being done, my liege");
               //Task testTask = taskList.Pop();
               //testTask.Execute();            
        }
    }
}

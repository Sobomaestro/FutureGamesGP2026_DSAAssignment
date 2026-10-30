using Environment.Tasks;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

namespace Environment
{
    public class Computer : MonoBehaviour, IInteractable
    {
        [SerializeField] public DebugPrintTask debugTasks;
        [SerializeField] public playerTaskManager taskManager;
        [SerializeField] public InteractableTasks interactaTasks;
        [SerializeField] public SecretTask secretTasks;
        [SerializeField] public List<Task> listOfDoodoo = new List<Task>();
        [SerializeField] Canvas computerUI;
        [SerializeField] Button emailButton;
        Stack<Task> taskList = new Stack<Task>();

        void Awake()
        {
     
        }

        public void RecycledTasks(Task thrown)
        {
            listOfDoodoo.Add(thrown);
        }


        public virtual void OnInteract()
        {
            computerUI.enabled = true;            
            
            //Task testTask = taskList.Pop();
            //testTask.Execute();
        }

        public string AddTask()
        {
            if (listOfDoodoo.Count > 0)
            {
                int randomIndex = Random.Range(0, listOfDoodoo.Count);
                taskManager.TaskAdder(listOfDoodoo[randomIndex]);
                Task temp = listOfDoodoo[randomIndex];
                listOfDoodoo.RemoveAt(randomIndex);                
                return temp.ToString();
            }
            else Debug.Log("No more tasks in need of being done, my liege");
            return null;
        }
    }
}

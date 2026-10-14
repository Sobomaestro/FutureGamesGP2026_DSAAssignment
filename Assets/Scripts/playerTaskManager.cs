using UnityEngine;
using System.Collections.Generic;
using TMPro;

namespace Environment.Tasks {
    public class playerTaskManager : MonoBehaviour {
        //[SerializeField] Task tasks;
        [SerializeField] TextMeshProUGUI taskText;
        public Stack2TheStackening<Task> playerTasks = new Stack2TheStackening<Task>();
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start() {

        }

        // Update is called once per frame
        void Update() {

        }
        public void TaskAdder(Task incomingTask) {
            playerTasks.Push(incomingTask);
            taskText.text = playerTasks.Peek().ToString();
        }
        public void UpdateTask()            
            {
            if(playerTasks.Count > 0) {
                taskText.text = playerTasks.Peek().ToString();
            }
            else taskText.text = "All tasks completed my liege. Good job";
        }
        public Task TaskExecutor()
        {
            return playerTasks.Pop();
        }
    }
}

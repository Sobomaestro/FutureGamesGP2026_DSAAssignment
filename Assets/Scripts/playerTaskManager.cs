using UnityEngine;
using System.Collections.Generic;
using TMPro;
using JetBrains.Annotations;
using System.Xml.Serialization;

namespace Environment.Tasks {
    public class playerTaskManager : MonoBehaviour {
        //[SerializeField] Task tasks;
        [SerializeField] TextMeshProUGUI taskText;
        public Stack2TheStreets<Task> playerTasks = new Stack2TheStreets<Task>();
        // Start is called once before the first execution of Update after the MonoBehaviour is created

        Wiiwoo<int> age = new Wiiwoo<int>(); 
        private void Awake() {
            age = new();
        }
        void Start() {

        }

        // Update is called once per frame
        void Update() {

        }
        public void TaskAdder(Task incomingTask) {
            playerTasks.PushIt(incomingTask);
            UpdateTask();
        }
        public void UpdateTask()            
            {
            if(playerTasks.Count > 0) {
                taskText.text = playerTasks.Peekaboo().ToString();
            }
            else taskText.text = "All tasks completed my liege. Good job";
        }
        public Task TaskExecutor()
        {
            return playerTasks.PopIt();
        }
        public void IThrewItOnTheGround() {
            playerTasks.ClearTheStreets();
            Debug.Log("Maaaaaaan");
            UpdateTask();
        }
    }
}

using UnityEngine;
using System.Collections.Generic;
using TMPro;

namespace Environment.Tasks { 
    public class playerTaskManager : MonoBehaviour {
        //[SerializeField] Task tasks;
        [SerializeField] TextMeshProUGUI taskText;
        Stack<Task> playerTasks = new Stack<Task>();
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start() {

        }

        // Update is called once per frame
        void Update() {

        }
        public void TaskAdder(Task incomingTask)
        {
            playerTasks.Push(incomingTask);
            taskText.text = playerTasks.Peek().ToString();
        }
    }
}

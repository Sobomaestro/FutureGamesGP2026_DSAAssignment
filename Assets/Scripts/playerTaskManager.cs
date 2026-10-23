using UnityEngine;
using System.Collections.Generic;
using TMPro;
using JetBrains.Annotations;
using System.Xml.Serialization;
using System.Threading;
using UnityEngine.Experimental.GlobalIllumination;
using System;
using UnityEngine.UI;

namespace Environment.Tasks
{
    public class playerTaskManager : MonoBehaviour
    {
        //[SerializeField] Task tasks;
        [SerializeField] TextMeshProUGUI taskText;
        public Computer computer;
        public JsonPuter jsonComputer;
        public ScriptableObject employeeTask;
        [SerializeField] Light light;
        [SerializeField] Light spotLight;
        [SerializeField] Button emailButton;
        [SerializeField] Button taskButton;
        public Stack2TheStreets<Task> playerTasks = new Stack2TheStreets<Task>();
        public List<EmployeeList> employeeList = new List<EmployeeList>();
        float t = 0;
        float redTemp = 1500;
        float baseTemp = 5000;
        float lerpTime = 1.5f;
        float currentTemp;
        float lerpedTemp;
        float currentIntensity;
        float lerpedIntensity;
        Color lerpedColor;
        Color currentColor;
        Color baseColor = Color.white;
        Color Target = Color.red;
        float timer;
        bool colorLerp = false;
        bool colorReset = false;
        Task currentTask;
        // Start is called once before the first execution of Update after the MonoBehaviour is created

        Wiiwoo<int> age = new Wiiwoo<int>();
        private void Awake()
        {
            age = new();
        }
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if (colorLerp == true)
            {   
                lerpedTemp = Mathf.Lerp(currentTemp, redTemp, timer);
                light.colorTemperature = lerpedTemp;
                lerpedColor = Color.Lerp(currentColor, Target, timer);
                light.color = lerpedColor;
                lerpedIntensity = Mathf.Lerp(currentIntensity, 1000, timer);
                spotLight.intensity = lerpedIntensity;
                timer += 0.004f;
                if (timer >= 1)
                { colorLerp = false; Debug.Log(colorLerp); }
            }
            if (colorReset == true)
            {
                lerpedTemp = Mathf.Lerp(currentTemp, baseTemp, timer);
                light.colorTemperature = lerpedTemp;
                lerpedColor = Color.Lerp(currentColor, baseColor, timer);
                light.color = lerpedColor;
                lerpedIntensity = Mathf.Lerp(currentIntensity, 0, timer);
                spotLight.intensity = lerpedIntensity;
                timer += 0.01f;
                if (timer >= 1)
                    { colorReset = false; Debug.Log(colorReset); }
            }
        }
        public void TaskAdder(Task incomingTask)
        {
            playerTasks.PushIt(incomingTask);
            UpdateTask(incomingTask);
        }
        public void LerpReset()
        {
            light.colorTemperature = baseTemp;
            light.color = baseColor;
            spotLight.intensity = 0;
        }

        public void UpdateTask(Task incomingTask)
        {
            currentTask = incomingTask;
            if (playerTasks.Count > 0)
            {
                taskText.text = playerTasks.Peekaboo().ToString();
            }
            else taskText.text = "All tasks completed my liege. Good job";
            CheckEmail();
        }
        public void LazyTasker()
        {
            taskText.text = "You should go check the computer....";
        }
        public Task TaskExecutor()
        {
            Task temp = playerTasks.PopIt();
            currentTask = TaskPeeker();
            UpdateTask(currentTask);
            return temp;
            
        }
        public Task TaskPeeker()
        {
            return playerTasks.Peekaboo();
        }
        public void IThrewItOnTheGround()
        {
            if (playerTasks.Count > 0)
            {
                while (playerTasks.Count > 0)
                {
                    Task temp = playerTasks.PopIt();
                    computer.RecycledTasks(temp);
                    if (computer.listOfDoodoo.Count > 0)
                    { taskButton.interactable = true; }
                }
                ForsakenTasks();
                ColorTemperatureLerp();
                colorLerp = true;
            }
            else { taskText.text = "you tried to throw away your problems, but you don't have any problems."; }

        }
        void ColorTemperatureLerp()
        {
            timer = 0;
            currentTemp = light.colorTemperature;
            currentColor = light.color;
        }
        public void ForsakenTasks()
        {
            taskText.text = "Thought you could get away? :)";
        }
        void CheckEmail()
        {
            if (currentTask is EmailTask beastTask)
            {
                emailButton.interactable = true;
            }
            else emailButton.interactable = false;
        }
    }
}

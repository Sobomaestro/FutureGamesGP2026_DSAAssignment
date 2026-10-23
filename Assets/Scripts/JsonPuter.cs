using Environment;
using Environment.Tasks;
using UnityEngine;
using System.Collections.Generic;
using System;
using System.Text.Json.Serialization;
using System.Runtime.Serialization.Json;
using System.Runtime.Serialization;
using System.Globalization;

public class JsonPuter : Computer, IInteractable
{
    public Employees employees;
    public TextAsset jsonFile;
    public EmployeeList myEmployeeList = new EmployeeList();
    string[] name = new string[5];
    int[] employeeID = new int[5];
    bool[] hasEngineRoomClearance = new bool[5];
    string[] lastEntranceInEngineRoom = new string[5];
    string[] lastExitFromEngineRoom = new string[5];
    Employees[] employeeArray = new Employees[5];
    [SerializeField] DateTime[] lastExitDateTime = new DateTime[3];
    public InteractableTasks inter;
    public ScriptableObject scriptableObject;
    public override void OnInteract() {

        Task incomingTask = taskManager.TaskPeeker();
        Debug.Log(incomingTask);
        if (incomingTask is InteractableTasks interactask)
        {
            taskManager.TaskExecutor();
            incomingTask.Execute();
            ExecuteJason();
            //Debug.Log(jsonFile.text);
            //myEmployeeList = JsonUtility.FromJson<EmployeeList>(jsonFile.text);
            //var dateTime = DateTime.Parse(myEmployeeList.employees[0].lastEntranceInEngineRoom);
            //for (int i = 0; i < myEmployeeList.employees.Count; i++)
            //{
            //    lastExitDateTime[i] = DateTime.Parse(myEmployeeList.employees[i].lastEntranceInEngineRoom);
            //    Debug.Log(lastExitDateTime[i]);
            //}
        }
        Debug.Log("you have no available tasks for this workstation");
    }

    public void ExecuteJason()
    {
        myEmployeeList = JsonUtility.FromJson<EmployeeList>(inter.jsonFile.text);
        var dateTime = DateTime.Parse(myEmployeeList.employees[0].lastEntranceInEngineRoom);
        for (int i = 0; i < myEmployeeList.employees.Count; i++)
        {
            lastExitDateTime[i] = DateTime.Parse(myEmployeeList.employees[i].lastEntranceInEngineRoom);
            Debug.Log(lastExitDateTime[i]);
        }
    }



}

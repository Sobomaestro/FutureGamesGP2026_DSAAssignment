using Environment.Tasks;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;

public class JsonUI : MonoBehaviour
{
    public Employees employees;
    public TextAsset jsonFile;
    public EmployeeList myEmployeeList = new EmployeeList();
    [SerializeField] playerTaskManager taskManager;
    [SerializeField] Button loadButton;
    [SerializeField] Button sortButton;
    [SerializeField] Button exitButton;
    [SerializeField] TextMeshProUGUI jsonTextbox;
    [SerializeField] DateTime[] lastExitDateTime = new DateTime[3];
    [SerializeField] Canvas jsonUI;
    public InteractableTasks inter;
    public SortTaskScript employeeSorter;
    [SerializeField] Listcarrier listCarrier;
    
    string[] name = new string[5];
    int[] employeeID = new int[5];
    bool[] hasEngineRoomClearance = new bool[5];
    string[] lastEntranceInEngineRoom = new string[5];
    string[] lastExitFromEngineRoom = new string[5];
    Employees[] employeeArray = new Employees[5];


    public void LoadButton()
    {
        Task incomingTask = taskManager.TaskPeeker();
        Debug.Log(incomingTask);
        if (incomingTask is InteractableTasks interactask)
        {
            taskManager.TaskExecutor();
            incomingTask.Execute();
            ExecuteJason();
            taskManager.TaskAdder(employeeSorter);
        }
        
    }
    public void SortButton()
    {
        Task incomingTask = taskManager.TaskPeeker();
        Debug.Log(incomingTask);
        if (incomingTask is SortTaskScript employeeSorter)
        {
            taskManager.TaskExecutor();
            incomingTask.Execute();
            listCarrier.ListSortSend();
        }
    }
    public void ExitButton()
    {
        jsonUI.enabled = false;
    }

    public void ExecuteJason()
    {
        myEmployeeList = JsonUtility.FromJson<EmployeeList>(inter.jsonFile.text);
        var dateTime = DateTime.Parse(myEmployeeList.employees[0].lastEntranceInEngineRoom);
        listCarrier.ListIntake(myEmployeeList);
        //PrintJson(myEmployeeList);
    }

    public void PrintJson(EmployeeList employeeList)
    {
        Debug.Log("Printing!");
        jsonTextbox.text = " ";
        foreach (Employees employees in employeeList.employees)
        {
            jsonTextbox.text += employees.name.ToString() + ", EmployeeID: " + employees.employeeId.ToString() + "\r\n";
            jsonTextbox.text += "Has engine room clearance? " + employees.hasEngineRoomClearance.ToString() + "\r\n";
            jsonTextbox.text += "Last entrance in engine room: " + employees.lastEntranceInEngineRoom.ToString() + "\r\n";
            jsonTextbox.text += "Last exit from engine room: " + employees.lastExitFromEngineRoom.ToString() + "\r\n";
            jsonTextbox.text += "____________________\r\n";
        }
    }

    //public void SortButtonClick()
    //{
    //    jsonTextbox.text = string.Empty;        
    //    listCarrier.ListSortSend();
    //    //EmployeeList employeeList = new EmployeeList();
    //    //employeeList = JsonUtility.FromJson<EmployeeList>(inter.jsonFile.text);
    //    //EmployeeList sortedList = Divider(myEmployeeList);
    //    //PrintJson(sortedList);
    //}

    //public void TaskActivated()
    //{
    //    EmployeeList employeeList = new EmployeeList();
    //    employeeList = JsonUtility.FromJson<EmployeeList>(inter.jsonFile.text);
    //    EmployeeList sortedList = Divider(employeeList);
    //    PrintJson(sortedList);
    //}

    public EmployeeList Divider(EmployeeList myEmployeeList)
    {

        int length = myEmployeeList.employees.Count;
        if (length <= 1) { return myEmployeeList; }
        EmployeeList leftList = new();
        EmployeeList rightList = new EmployeeList();
        leftList.employees = new();
        rightList.employees = new();
        int middle = length / 2;

        int i = 0; //left list
        int j = 0; //right list
            for (; i < length; i++)
            {
                if (i < middle)
                {
                    leftList.employees.Add(myEmployeeList.employees[i]);
                }
                else
                {
                    rightList.employees.Add(myEmployeeList.employees[i]);
                    j++;
                }
            }

            Divider(leftList);
            Divider(rightList);
            EmployeeList sortedList = FrankenMerger(rightList, leftList, myEmployeeList);
            return sortedList;
    }
    public EmployeeList FrankenMerger(EmployeeList rightList, EmployeeList leftList, EmployeeList myEmployeeList)
    {
        Debug.Log("kör frankenmerger");
        int leftSize = leftList.employees.Count;
        int rightSize = rightList.employees.Count;
        int i = 0, l = 0, r = 0;

        while (l < leftSize && r < rightSize)
        {
            DateTime leftSide = DateTime.Parse(leftList.employees[l].lastExitFromEngineRoom);
            DateTime rightSide = DateTime.Parse(rightList.employees[r].lastExitFromEngineRoom);
            if (leftSide.CompareTo(rightSide) < 0)
            {
                Debug.Log("compared "+DateTime.Parse(rightList.employees[l].lastEntranceInEngineRoom));
                myEmployeeList.employees[i] = rightList.employees[r];
                i++; r++;
            }
            else
            {
                myEmployeeList.employees[i] = leftList.employees[l];
                i++; l++;
            }
        }
        while (l < leftSize)
        {
            myEmployeeList.employees[i] = leftList.employees[l];
            i++; l++;
        }
        while (r < rightSize)
        {
            myEmployeeList.employees[i] = rightList.employees[r];
            i++; r++;
        }
        //foreach (Employees employee in  myEmployeeList.employees)
        //{
        //    Debug.Log(employee.name + " " + employee.lastEntranceInEngineRoom);
        //}
        return myEmployeeList;
    }
    
}
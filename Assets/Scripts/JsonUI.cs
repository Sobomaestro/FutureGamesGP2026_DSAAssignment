using Environment.Tasks;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

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
        }
    }
    public void SortButton()
    {

    }
    public void ExitButton()
    {
        jsonUI.enabled = false;
    }

    public void ExecuteJason()
    {
        myEmployeeList = JsonUtility.FromJson<EmployeeList>(inter.jsonFile.text);
        var dateTime = DateTime.Parse(myEmployeeList.employees[0].lastEntranceInEngineRoom);
        //for (int i = 0; i < myEmployeeList.employees.Count; i++)
        //{
        //    lastExitDateTime[i] = DateTime.Parse(myEmployeeList.employees[i].lastEntranceInEngineRoom);
        //    Debug.Log(lastExitDateTime[i]);
        //}
        PrintJson(myEmployeeList);
    }

    public void PrintJson(EmployeeList employeeList)
    {
        Debug.Log("Printing!");
        jsonTextbox.text = " ";
        foreach (Employees employees in myEmployeeList.employees)
        {
            jsonTextbox.text += employees.name.ToString() + ", EmployeeID: " + employees.employeeId.ToString() + "\r\n";
            jsonTextbox.text += "Has engine room clearance? " + employees.hasEngineRoomClearance.ToString() + "\r\n";
            jsonTextbox.text += "Last entrance in engine room: " + employees.lastEntranceInEngineRoom.ToString() + "\r\n";
            jsonTextbox.text += "Last exit from engine room: " + employees.lastExitFromEngineRoom.ToString() + "\r\n";
            jsonTextbox.text += "____________________\r\n";
        }
    }

    public void SortButtonClick()
    {
        
        EmployeeList employeeList = new EmployeeList();
        employeeList = JsonUtility.FromJson<EmployeeList>(inter.jsonFile.text);
        myEmployeeList = Divider(myEmployeeList);
        Debug.Log("hello");
        PrintJson(myEmployeeList);
        Debug.Log("Dude");
    }

    public EmployeeList Divider(EmployeeList myEmployeeList)
    {

        int length = myEmployeeList.employees.Count;
        if (length <= 1) { return myEmployeeList; }
        EmployeeList leftList = new();
        EmployeeList rightList = new EmployeeList();
        leftList.employees = new();
        rightList.employees = new();

        int middle = length / 2;

        Debug.Log(rightList.employees.Count);
        Debug.Log(leftList.employees.Count);
        //Employeeees leftList = new EmployeeList();


        int i = 0; //left list
        int j = 0; //right list
                   //foreach (Employees employee in myEmployeeList.employees)
                   //{
                   //    if (i < middle)
                   //    {
                   //        leftList.employees.Add(employee); i++;
                   //    }
                   //    else
                   //    {
                   //        rightList.employees.Add(employee); i++;
                   //    }
                   // }
            for (; i < length; i++)
            {
                Debug.Log("i är: " + i);
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
            FrankenMerger(rightList, leftList, myEmployeeList);
            return myEmployeeList;
    }
    public void FrankenMerger(EmployeeList rightList, EmployeeList leftList, EmployeeList myEmployeeList)
    {
        int leftSize = leftList.employees.Count;
        int rightSize = rightList.employees.Count;
        int i = 0, l = 0, r = 0;

        while (l < leftSize && r < rightSize)
        {
            if (DateTime.Parse(rightList.employees[l].lastEntranceInEngineRoom) < DateTime.Parse(leftList.employees[r].lastEntranceInEngineRoom))
            {
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
    }
}

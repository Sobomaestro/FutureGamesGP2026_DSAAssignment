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
    [SerializeField] Canvas jsonUI;
    public InteractableTasks inter;
    public SortTaskScript employeeSorter;
    [SerializeField] Listcarrier listCarrier;

    void Awake()
    {
        myEmployeeList.Employees = new();
    }

    public void LoadButton()
    {
        Task incomingTask = taskManager.TaskPeeker();
        Debug.Log(incomingTask);
        if (incomingTask is InteractableTasks interactask)
        {
            taskManager.TaskExecutor();
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
            //listCarrier.ListSortSend();
        }
    }
    public void ExitButton()
    {
        jsonUI.enabled = false;
    }

    public void ExecuteJason()
    {
        myEmployeeList = JsonUtility.FromJson<EmployeeList>(inter.jsonFile.text);
        //var dateTime = DateTime.Parse(myEmployeeList.employees[0].lastEntranceInEngineRoom);
        Debug.Log("the length of the list going out is: " + myEmployeeList.Employees.Count);
        listCarrier.ListIntake(myEmployeeList);
        //PrintJson(myEmployeeList);
    }

    public void PrintJson(EmployeeList employeeList)
    {
        Debug.Log("Printing!");
        jsonTextbox.text = " ";
        foreach (Employees employees in employeeList.Employees)
        {
            jsonTextbox.text += employees.Name.ToString() + ", EmployeeID: " + employees.EmployeeId.ToString() + "\r\n";
            jsonTextbox.text += "Has engine room clearance? " + employees.HasEngineRoomClearance.ToString() + "\r\n";
            jsonTextbox.text += "Last entrance in engine room: " + employees.LastEntranceInEngineRoom.ToString() + "\r\n";
            jsonTextbox.text += "Last exit from engine room: " + employees.LastExitFromEngineRoom.ToString() + "\r\n";
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

    //public EmployeeList Divider(EmployeeList myEmployeeList)
    //{

    //    int length = myEmployeeList.Employees.Count;
    //    if (length <= 1) { return myEmployeeList; }
    //    EmployeeList leftList = new();
    //    EmployeeList rightList = new EmployeeList();
    //    leftList.Employees = new();
    //    rightList.Employees = new();
    //    int middle = length / 2;

    //    int i = 0; //left list
    //    int j = 0; //right list
    //        for (; i < length; i++)
    //        {
    //            if (i < middle)
    //            {
    //                leftList.Employees.Add(myEmployeeList.Employees[i]);
    //            }
    //            else
    //            {
    //                rightList.Employees.Add(myEmployeeList.Employees[i]);
    //                j++;
    //            }
    //        }

    //        Divider(leftList);
    //        Divider(rightList);
    //        EmployeeList sortedList = FrankenMerger(rightList, leftList, myEmployeeList);
    //        return sortedList;
    //}
    //public EmployeeList FrankenMerger(EmployeeList rightList, EmployeeList leftList, EmployeeList myEmployeeList)
    //{
    //    Debug.Log("kör frankenmerger");
    //    int leftSize = leftList.Employees.Count;
    //    int rightSize = rightList.Employees.Count;
    //    int i = 0, l = 0, r = 0;

    //    while (l < leftSize && r < rightSize)
    //    {
    //        DateTime leftSide = DateTime.Parse(leftList.Employees[l].LastExitFromEngineRoom);
    //        DateTime rightSide = DateTime.Parse(rightList.Employees[r].LastExitFromEngineRoom);
    //        if (leftSide.CompareTo(rightSide) < 0)
    //        {
    //            Debug.Log("compared "+DateTime.Parse(rightList.Employees[l].LastEntranceInEngineRoom));
    //            myEmployeeList.Employees[i] = rightList.Employees[r];
    //            i++; r++;
    //        }
    //        else
    //        {
    //            myEmployeeList.Employees[i] = leftList.Employees[l];
    //            i++; l++;
    //        }
    //    }
    //    while (l < leftSize)
    //    {
    //        myEmployeeList.Employees[i] = leftList.Employees[l];
    //        i++; l++;
    //    }
    //    while (r < rightSize)
    //    {
    //        myEmployeeList.Employees[i] = rightList.Employees[r];
    //        i++; r++;
    //    }
    //    //foreach (Employees employee in  myEmployeeList.employees)
    //    //{
    //    //    Debug.Log(employee.name + " " + employee.lastEntranceInEngineRoom);
    //    //}
    //    return myEmployeeList;
    }
using Environment.Tasks;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;

public class JsonUI : MonoBehaviour
{
    [SerializeField] playerTaskManager taskManager;
    [SerializeField] Button sortButton;
    [SerializeField] TextMeshProUGUI jsonTextbox;
    [SerializeField] Canvas jsonUI;
    public InteractableTasks inter;
    public SortTaskScript employeeSorter;
    [SerializeField] searchMenuUI searchMenu;


    public void LoadButton()
    {
        Task incomingTask = taskManager.TaskPeeker();
        Debug.Log(incomingTask);
        if (incomingTask is InteractableTasks interactask)
        {
            taskManager.TaskExecutor();            
            sortButton.interactable = true;
        }
        taskManager.TaskAdder(employeeSorter);

    }
    public void SortButton()
    {
        Task incomingTask = taskManager.TaskPeeker();
        Debug.Log(incomingTask);
        if (incomingTask is SortTaskScript employeeSorter)
        {
            taskManager.TaskExecutor();
            sortButton.interactable = false;
        }
        else { Debug.Log("This task dosen't fit in this computer slot..."); }
    }
    public void OpenSearchWindow()
    {
        searchMenu.searchMenu.interactable = true;
        searchMenu.searchMenu.alpha = 1.0f;
        searchMenu.searchMenu.blocksRaycasts = true;
    }

    public void ExitButton()
    {
        jsonUI.enabled = false;
    }

    public void PrintJson(EmployeeList employeeList)
    {
        string longAssString = null;        
        jsonTextbox.text = " ";
        int i = 1;
        jsonTextbox.maxVisibleCharacters = 1000000;
        foreach (Employees employees in employeeList.Employees)
        {
             longAssString +=  "Index: " + i + ". " +employees.Name + ", EmployeeID: " + employees.EmployeeId.ToString() + "\r\n" +
                                "Has engine room clearance? " + employees.HasEngineRoomClearance + "\r\n" +
                                "Last entrance in engine room: " + employees.LastEntranceInEngineRoom + "\r\n" +
                                "Last exit from engine room: " + employees.LastExitFromEngineRoom + "\r\n" +
                                "____________________\r\n";
            i++;
        }
        jsonTextbox.text = longAssString;
    }

    public void PrintSearchSpan(EmployeeList employees, int[] index)
    {
        string longAssString = null;
        jsonTextbox.text = " ";
        jsonTextbox.maxVisibleCharacters = 1000000;
        for (int i = index[0]; i < index[1]; i++)
        {
            longAssString += "Index: " + i + ". " + employees.Employees[i].Name + ", EmployeeID: " + employees.Employees[i].EmployeeId.ToString() + "\r\n" +
                                "Has engine room clearance? " + employees.Employees[i].HasEngineRoomClearance + "\r\n" +
                                "Last entrance in engine room: " + employees.Employees[i].LastEntranceInEngineRoom + "\r\n" +
                                "Last exit from engine room: " + employees.Employees[i].LastExitFromEngineRoom + "\r\n" +
                                "____________________\r\n";
        }
        jsonTextbox.text = longAssString;
    }

}
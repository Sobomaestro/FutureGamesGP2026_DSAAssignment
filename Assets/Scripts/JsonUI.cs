using Environment.Tasks;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

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
        for (int i = 0; i < myEmployeeList.employees.Count; i++)
        {
            lastExitDateTime[i] = DateTime.Parse(myEmployeeList.employees[i].lastEntranceInEngineRoom);
            Debug.Log(lastExitDateTime[i]);
        }

        foreach (Employees employees in myEmployeeList.employees)
        {
            jsonTextbox.text += employees.name.ToString() + ", EmployeeID: " + employees.employeeId.ToString() + "\r\n";
            jsonTextbox.text += "Has engine room clearance? " + employees.hasEngineRoomClearance.ToString() + "\r\n";
            jsonTextbox.text += "Last entrance in engine room: " + employees.lastEntranceInEngineRoom.ToString() + "\r\n";
            jsonTextbox.text += "Last exit from engine room: " + employees.lastExitFromEngineRoom.ToString() + "\r\n";
            jsonTextbox.text += "____________________\r\n";
        }
    }



}

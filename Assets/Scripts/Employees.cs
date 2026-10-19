using System;
using UnityEngine;

[System.Serializable]
public class Employees : MonoBehaviour
{
    public string name;
    public int employeeId;
    public bool hasEngineRoomClearance;
    public DateTime lastEntranceInEngineRoom;
    public DateTime lastExitFromEngineRoom;
    public void EmployeeDefault() {
        this.name = string.Empty;
        this.employeeId = 0;
        this.hasEngineRoomClearance = false;
        this.lastEntranceInEngineRoom = DateTime.MinValue;
        this.lastExitFromEngineRoom = DateTime.MinValue;
    }
}
[Serializable]
public class EmployeeArray {
    public Employees[] employeeArray;
}

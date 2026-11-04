using System;
using UnityEngine;
using System.Collections.Generic;


[Serializable]
public class Employees
{
    public string Name;
    public int EmployeeId;
    public bool HasEngineRoomClearance;
    public string LastEntranceInEngineRoom;
    public string LastExitFromEngineRoom;
    public DateTime parsedEnter;
    public DateTime parsedExit;

    //public Employees() {
    //    this.Name = null;
    //    this.EmployeeId = 0;
    //    this.HasEngineRoomClearance = false;
    //    this.LastEntranceInEngineRoom = null;
    //    this.LastExitFromEngineRoom = null;        
    //}
    public void Initialize()
    {
        parsedEnter = DateTime.Parse(LastEntranceInEngineRoom);
        parsedExit = DateTime.Parse(LastExitFromEngineRoom);
    }

}
[Serializable]

public class EmployeeList {
    public List<Employees> Employees = new List<Employees>();
    //public Employees[] employees;
}

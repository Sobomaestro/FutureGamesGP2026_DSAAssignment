using System;
using UnityEngine;
using System.Collections.Generic;


[Serializable]
public class Employees
{
    public string name;
    public int employeeId;
    public bool hasEngineRoomClearance;
    public string lastEntranceInEngineRoom;
    public string lastExitFromEngineRoom;

    public Employees() {
        this.name = null;
        this.employeeId = 0;
        this.hasEngineRoomClearance = false;
        this.lastEntranceInEngineRoom = null;
        this.lastExitFromEngineRoom = null;
    }


}
[Serializable]
public class EmployeeList {
    public List<Employees> employees = new List<Employees>();
    //public Employees[] employees;
}

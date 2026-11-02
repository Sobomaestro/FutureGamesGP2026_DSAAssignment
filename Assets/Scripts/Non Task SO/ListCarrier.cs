using UnityEngine;
using System.Collections.Generic;


namespace Environment.Tasks
{
    [CreateAssetMenu(fileName = "Listcarrier", menuName = "Scriptable Objects/Listcarrier")]
    public class Listcarrier : ScriptableObject
    {
        [SerializeField] EmployeeList employeeListSO = new EmployeeList();
        
        [SerializeField] SortTaskScript sortTask;
        JsonUI jsonUI;


        public void ListIntake(EmployeeList incomingList)            
        {
            employeeListSO.Employees = new();
            for (int i = 0; i < incomingList.Employees.Count; i++)
            {
                employeeListSO.Employees.Add(incomingList.Employees[i]);
            }            
            jsonUI = FindAnyObjectByType<JsonUI>();
            jsonUI.PrintJson(employeeListSO);
        }

        public void ListSortSend()
        {
            EmployeeList sortedList = new EmployeeList();
            sortedList = sortTask.Divider(employeeListSO);
            sortTask.Execute();
            jsonUI.PrintJson(sortedList);
        }




    }
}
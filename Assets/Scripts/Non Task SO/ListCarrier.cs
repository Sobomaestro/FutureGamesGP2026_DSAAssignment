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
            //employeeListSO = sortTask.Divider(employeeListSO);
            sortTask.QuickerThanSort(employeeListSO, 0, employeeListSO.Employees.Count-1);
            jsonUI = FindAnyObjectByType<JsonUI>();
            jsonUI.PrintJson(employeeListSO);
        }

    }
}
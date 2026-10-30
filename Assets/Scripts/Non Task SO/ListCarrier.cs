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
            int i = 0;
            employeeListSO.employees = new();
            foreach (Employees employee in incomingList.employees)
            {
                employeeListSO.employees.Add(employee);
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
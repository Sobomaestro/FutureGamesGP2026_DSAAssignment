using System;
using UnityEngine;


namespace Environment.Tasks
{
    [CreateAssetMenu(fileName = "SortTask", menuName = "Scriptable Objects/SortTask")]

    public class SortTaskScript : Task
    {
        [SerializeField] private string taskDescription = "Sort the list of employees to find the suspect, and save the world.";
        [SerializeField] public playerTaskManager taskManager;
        [SerializeField] public EmployeeList myEmployeeList;
        public override void Execute()
        {
            Debug.Log("Executing sorting task");
            //JsonUI jsonUI = GameObject.FindAnyObjectByType<JsonUI>();
            //jsonUI.TaskActivated();
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

            int i = 0; //left list
            int j = 0; //right list
            for (; i < length; i++)
            {
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
            EmployeeList sortedList = FrankenMerger(rightList, leftList, myEmployeeList);
            return sortedList;
        }
        public EmployeeList FrankenMerger(EmployeeList rightList, EmployeeList leftList, EmployeeList myEmployeeList)
        {
            Debug.Log("kör frankenmerger");
            int leftSize = leftList.employees.Count;
            int rightSize = rightList.employees.Count;
            int i = 0, l = 0, r = 0;

            while (l < leftSize && r < rightSize)
            {
                DateTime leftSide = DateTime.Parse(leftList.employees[l].lastExitFromEngineRoom);
                DateTime rightSide = DateTime.Parse(rightList.employees[r].lastExitFromEngineRoom);
                if (leftSide.CompareTo(rightSide) < 0)
                {
                    Debug.Log("compared " + DateTime.Parse(rightList.employees[l].lastEntranceInEngineRoom));
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
            //foreach (Employees employee in  myEmployeeList.employees)
            //{
            //    Debug.Log(employee.name + " " + employee.lastEntranceInEngineRoom);
            //}
            return myEmployeeList;
        }
    }
}
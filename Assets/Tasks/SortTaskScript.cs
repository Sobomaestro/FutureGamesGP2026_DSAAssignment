using System;
using UnityEngine;


namespace Environment.Tasks
{
    [CreateAssetMenu(fileName = "SortTask", menuName = "Scriptable Objects/SortTask")]

    public class SortTaskScript : Task
    {
        [SerializeField] private string taskDescription = "Sort the list of Employees to find the suspect, and save the world.";
        [SerializeField] public playerTaskManager taskManager;
        [SerializeField] public EmployeeList myEmployeeList;
        [SerializeField] public ScriptableObject listCarrier;
        public override void Execute()
        {
            Debug.Log("Executing sorting task");
           // Divider(myEmployeeList);
        }
        public EmployeeList Divider(EmployeeList dividedEmployees)
        {

            int length = dividedEmployees.Employees.Count;
            if (length <= 1) { return dividedEmployees; }
            EmployeeList leftList = new();
            EmployeeList rightList = new EmployeeList();
            leftList.Employees = new();
            rightList.Employees = new();
            int middle = length / 2;
            int leftSize = middle;
            int rightSize = dividedEmployees.Employees.Count - middle;

            //int i = 0; //left list
            //int j = 0; //right list

            for (int l = 0; l < leftSize; l++)
            {
                leftList.Employees.Add(dividedEmployees.Employees[l]);
            }
            for (int r = 0; r < rightSize; r++)
            {
                rightList.Employees.Add(dividedEmployees.Employees[leftSize + r]);
            }


            //for (; i < length; i++)
            //{
            //    if (i < middle)
            //    {
            //        leftList.Employees.Add(dividedEmployees.Employees[i]);
            //    }
            //    else
            //    {
            //        rightList.Employees.Add(dividedEmployees.Employees[i]);
            //        j++;
            //    }
            //}

            Divider(leftList);
            Divider(rightList);
            EmployeeList sortedList = FrankenMerger(rightList, leftList, dividedEmployees);
            return sortedList;
        }
        public EmployeeList FrankenMerger(EmployeeList rightList, EmployeeList leftList, EmployeeList frankenEmployees)
        {
            Debug.Log("kör frankenmerger");
            int leftSize = leftList.Employees.Count;
            int rightSize = rightList.Employees.Count;
            int i = 0, l = 0, r = 0;

            while (l < leftSize && r < rightSize)
            {
                DateTime leftSide = DateTime.Parse(leftList.Employees[l].LastExitFromEngineRoom);
                DateTime rightSide = DateTime.Parse(rightList.Employees[r].LastExitFromEngineRoom);
                if (leftSide.CompareTo(rightSide) < 0)
                {
                    frankenEmployees.Employees.Add(leftList.Employees[l]);
                    l++;
                }
                else
                {
                    frankenEmployees.Employees.Add(rightList.Employees[r]);
                    r++;
                }
            }
            //while (l < leftSize)
            //{
            //    frankenEmployees.Employees[i] = leftList.Employees[l];
            //    i++; l++;
            //}
            //while (r < rightSize)
            //{
            //    frankenEmployees.Employees[i] = rightList.Employees[r];
            //    i++; r++;
            //}
            //foreach (Employees employee in  frankenEmployees.Employees)
            //{
            //    Debug.Log(employee.name + " " + employee.LastEntranceInEngineRoom);
            //}
            return frankenEmployees;
        }
    }
}
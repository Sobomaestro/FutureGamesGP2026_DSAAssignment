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
        public override void Execute()
        {
            Debug.Log("Executing sorting task");
            //JsonUI jsonUI = GameObject.FindAnyObjectByType<JsonUI>();
            //jsonUI.TaskActivated();
        }
        public EmployeeList Divider(EmployeeList myEmployeeList)
        {

            int length = myEmployeeList.Employees.Count;
            if (length <= 1) { return myEmployeeList; }
            EmployeeList leftList = new();
            EmployeeList rightList = new EmployeeList();
            leftList.Employees = new();
            rightList.Employees = new();
            int middle = length / 2;

            int i = 0; //left list
            int j = 0; //right list
            for (; i < length; i++)
            {
                if (i < middle)
                {
                    leftList.Employees.Add(myEmployeeList.Employees[i]);
                }
                else
                {
                    rightList.Employees.Add(myEmployeeList.Employees[i]);
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
            int leftSize = leftList.Employees.Count;
            int rightSize = rightList.Employees.Count;
            int i = 0, l = 0, r = 0;

            while (l < leftSize && r < rightSize)
            {
                DateTime leftSide = DateTime.Parse(leftList.Employees[l].LastExitFromEngineRoom);
                DateTime rightSide = DateTime.Parse(rightList.Employees[r].LastExitFromEngineRoom);
                if (leftSide.CompareTo(rightSide) < 0)
                {
                    Debug.Log("compared " + DateTime.Parse(rightList.Employees[l].LastEntranceInEngineRoom));
                    myEmployeeList.Employees[i] = rightList.Employees[r];
                    i++; r++;
                }
                else
                {
                    myEmployeeList.Employees[i] = leftList.Employees[l];
                    i++; l++;
                }
            }
            while (l < leftSize)
            {
                myEmployeeList.Employees[i] = leftList.Employees[l];
                i++; l++;
            }
            while (r < rightSize)
            {
                myEmployeeList.Employees[i] = rightList.Employees[r];
                i++; r++;
            }
            //foreach (Employees employee in  myEmployeeList.Employees)
            //{
            //    Debug.Log(employee.name + " " + employee.LastEntranceInEngineRoom);
            //}
            return myEmployeeList;
        }
    }
}
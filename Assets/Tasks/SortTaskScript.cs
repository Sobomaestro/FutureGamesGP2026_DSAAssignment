using System;
using System.Linq;
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
        EmployeeList mergeList = new EmployeeList();

        public override void Execute()
        {
            Debug.Log("Executing sorting task");
        }
        public EmployeeList Divider(EmployeeList dividedEmployees)
        {
            int length = dividedEmployees.Employees.Count;
            if (length <= 1) { return dividedEmployees; }
            EmployeeList leftList = new EmployeeList();
            EmployeeList rightList = new EmployeeList();
            leftList.Employees = new();
            rightList.Employees = new();
            int middle = length / 2;
            int leftSize = middle;
            int rightSize;
            if (dividedEmployees.Employees.Count % 2 == 0)
            { rightSize = middle; }
            else { rightSize = middle + 1; }

            for (int l = 0; l < leftSize; l++)
            {
                leftList.Employees.Add(dividedEmployees.Employees[l]);
            }
            for (int r = rightSize; r < dividedEmployees.Employees.Count; r++)
            {
                rightList.Employees.Add(dividedEmployees.Employees[r]);
            }

            Divider(leftList);
            Divider(rightList);
            return FrankenMerger(rightList, leftList);
        }
        public EmployeeList FrankenMerger(EmployeeList rightList, EmployeeList leftList)
        {
            EmployeeList mergeList = new EmployeeList();
            mergeList.Employees = new();
            int leftSize = leftList.Employees.Count;
            int rightSize = rightList.Employees.Count;
            int l = 0, r = 0;
            Debug.Log(leftSize + " " + rightSize);
            while (leftList.Employees.Count > 0 || rightList.Employees.Count > 0)
            {
                if (leftList.Employees.Count > 0 && rightList.Employees.Count > 0)
                {
                    DateTime leftSide = DateTime.Parse(leftList.Employees[0].LastExitFromEngineRoom);
                    DateTime rightSide = DateTime.Parse(rightList.Employees[0].LastExitFromEngineRoom);
                    if (leftSide.CompareTo(rightSide) < 0)
                    {
                        mergeList.Employees.Add(leftList.Employees[0]);
                        leftList.Employees.RemoveAt(0);
                    }
                    else
                    {
                        mergeList.Employees.Add(rightList.Employees[0]);
                        rightList.Employees.RemoveAt(0);
                    }
                }
                else if (leftList.Employees.Count > 0)
                {
                    mergeList.Employees.Add(leftList.Employees[0]);
                    leftList.Employees.RemoveAt(0);
                }
                else if (rightList.Employees.Count > 0)
                {
                    mergeList.Employees.Add(rightList.Employees[0]);
                    rightList.Employees.RemoveAt(0);
                }
            }
            //while (l < leftSize && r < rightSize)
            //{
            //    DateTime leftSide = DateTime.Parse(leftList.Employees[l].LastExitFromEngineRoom);
            //    DateTime rightSide = DateTime.Parse(rightList.Employees[r].LastExitFromEngineRoom);
                
                
            //    else
            //    {
            //        mergeList.Employees.Add(rightList.Employees[r]);
            //        r++;
            //    }                
            //}
            //while (l < leftSize)
            //{
            //    myEmployeeList.Employees.Add(leftList.Employees[l]);
            //    l++;
            //}
            //while (r < rightSize)
            //{
            //    myEmployeeList.Employees.Add(rightList.Employees[r]);
            //    r++;
            //}

            return mergeList;
        }
    }
}
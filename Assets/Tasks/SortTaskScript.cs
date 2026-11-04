using System;
using System.Linq;
using Unity.Jobs;
using UnityEngine;
using UnityEngine.Assemblies;
using UnityEngine.UIElements;


namespace Environment.Tasks
{
    [CreateAssetMenu(fileName = "SortTask", menuName = "Scriptable Objects/SortTask")]

    public class SortTaskScript : Task
    {
        [SerializeField] private string taskDescription = "Sort the list of Employees to find the suspect.";
        [SerializeField] public playerTaskManager taskManager;
        [SerializeField] public EmployeeList myEmployeeList;
        [SerializeField] public InteractableTasks listTask;
        [SerializeField] JsonUI jsonUI;
        EmployeeList mergeList = new EmployeeList();

        public override void Execute()
        {
            listTask.SortList();
        }
        int numberOfRecursions;

        public int Partition(EmployeeList list, int low, int high)
        {
            int pivot = high;
            int i = low - 1;

            for (int j = low; j < high; j++)
            {
                //Debug.Log($"i = {i}, j = {j}");
                if (list.Employees[j].parsedExit.CompareTo(list.Employees[pivot].parsedExit) < 0)
                {
                    i++;
                    Employees temp = list.Employees[j];
                    list.Employees[j] = list.Employees[i];
                    list.Employees[i] = temp;
                }
            }
            i++;
            Employees temp2 = list.Employees[i];
            list.Employees[i] = list.Employees[high];
            list.Employees[high] = temp2;

            return i;
        }


        public void QuickerThanQuicksort(EmployeeList intakeList, int low, int high)
        {
            //Debug.Log("number of recursions: " + numberOfRecursions++);
            //Debug.Log($"Low: {low}, high: {high}");
            if (high <= low) return;

            int pivotIndex = Partition(intakeList, low, high);
            QuickerThanQuicksort(intakeList, low, pivotIndex - 1);
            QuickerThanQuicksort(intakeList, pivotIndex + 1, high);





            //public EmployeeList Divider(EmployeeList dividedEmployees)
            //{
            //    int length = dividedEmployees.Employees.Count; //<---
            //    if (length < 1) { return dividedEmployees; }
            //    EmployeeList leftList = new();
            //    EmployeeList rightList = new();
            //    leftList.Employees = new();
            //    rightList.Employees = new();
            //    int middle = length / 2;
            //    int leftSize = middle;
            //    int rightSize = length - middle;

            //    //if (length % 2 == 0)
            //    //{ rightSize = middle; }
            //    //else { rightSize = middle + 1; }
            //    Debug.Log($"Leftsize: {leftSize} + Rightsize {rightSize}  = middle{middle}");

            //    for (int l = 0; l < leftSize; l++)
            //    {
            //        leftList.Employees.Add(dividedEmployees.Employees[l]);
            //    }
            //    for (int r = middle; r < length; r++)
            //    {
            //        rightList.Employees.Add(dividedEmployees.Employees[r]);
            //    }

            //    leftList = Divider(leftList);
            //    rightList = Divider(rightList);
            //    return FrankenMerger(leftList, rightList);
            //}
            //public EmployeeList FrankenMerger(EmployeeList rightList, EmployeeList leftList)
            //{
            //    EmployeeList mergeList = new EmployeeList { Employees = new() };
            //    int leftSize = leftList.Employees.Count;
            //    int rightSize = rightList.Employees.Count;
            //    int l = 0, r = 0;
            //    Debug.Log(leftSize + " " + rightSize);
            //    while (leftSize > 0 || rightSize > 0)
            //    {
            //        leftSize = leftList.Employees.Count;
            //        rightSize = rightList.Employees.Count;
            //        if (leftSize > 0 && rightSize > 0)
            //        {
            //            DateTime leftSide = DateTime.Parse(leftList.Employees[0].LastExitFromEngineRoom);
            //            DateTime rightSide = DateTime.Parse(rightList.Employees[0].LastExitFromEngineRoom);
            //            if (leftSide.CompareTo(rightSide) <= 0)
            //            {
            //                mergeList.Employees.Add(leftList.Employees[0]);
            //                leftList.Employees.RemoveAt(0);
            //            }
            //            else
            //            {
            //                mergeList.Employees.Add(rightList.Employees[0]);
            //                rightList.Employees.RemoveAt(0);
            //            }
            //        }
            //        else if (leftList.Employees.Count > 0)
            //        {
            //            mergeList.Employees.Add(leftList.Employees[0]);
            //            leftList.Employees.RemoveAt(0);
            //        }
            //        else if (rightList.Employees.Count > 0)
            //        {
            //            mergeList.Employees.Add(rightList.Employees[0]);
            //            rightList.Employees.RemoveAt(0);
            //        }
            //    }

            //    return mergeList;
            //}

        }
    }
}










    





//while (l < leftSize && r < rightSize)
//{
//    DateTime leftSide = DateTime.Parse(leftList.Employees[l].LastExitFromEngineRoom);
//    DateTime rightSide = DateTime.Parse(rightList.Employees[r].LastExitFromEngineRoom);
//    if (leftSide.CompareTo(rightSide) < 0)
//    {
//        mergeList.Employees.Add(leftList.Employees[l]);
//        l++;
//    }
//    else
//    {
//        mergeList.Employees.Add(rightList.Employees[r]);
//        r++;
//    }
//    while (l < leftSize)
//    {
//        myEmployeeList.Employees.Add(leftList.Employees[l]);
//        l++;
//    }
//    while (r < rightSize)
//    {
//        myEmployeeList.Employees.Add(rightList.Employees[r]);
//        r++;
//    }
//}




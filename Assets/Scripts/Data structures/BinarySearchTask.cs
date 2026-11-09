using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;


namespace Environment.Tasks
{
    [CreateAssetMenu(fileName = "BinarySearchTask", menuName = "Scriptable Objects/BinarySearchTask")]
    public class BinarySearchTask : ScriptableObject
    {
        EmployeeList employees = new EmployeeList();
        EmployeeList indexCutList = new EmployeeList();

        public int lowIndex;
        public int highIndex;
        public int midIndex;
        

        public int[] IntakeSearchData(EmployeeList listToSearch, DateTime lowSearchFloor, DateTime highSearchRoof)
        {
            int[] indexArray = new int[2];
            int length = listToSearch.Employees.Count;            
            indexArray[0] = MorgarySearch(0, length, lowSearchFloor, listToSearch);

            indexArray[1] = MorgarySearch(indexArray[0], length, highSearchRoof, listToSearch);
            
            return indexArray;
        }

        public int MorgarySearch(int low, int high, DateTime date, EmployeeList employeeList)
        {
            int middle = employeeList.Employees.Count / 2;

            while (high - low > 1)
            {
                middle = low + (high - low) / 2;
                if (employeeList.Employees[middle].parsedExit.CompareTo(date) > 0)
                {
                    high = middle;
                }
                else
                {
                    low = middle;
                }
            }
            return middle;

            //if (high - low > 1)
            //{
            //    if (employeeList.Employees[middle].parsedExit.CompareTo(date) > 0)
            //    {
            //        Debug.Log($"midIndex is {midIndex} ");
            //        RecursiveBinary(low, middle, date, employeeList);
            //    }
            //    else
            //    {
            //        Debug.Log($"midIndex is {midIndex} ");
            //        RecursiveBinary(middle, high, date, employeeList);
            //    }
            //}
            //return middle;
        }
    }
}


//public EmployeeList BinarySearchSpan(EmployeeList searchList, DateTime low, DateTime high)
//{
//    int length = searchList.Employees.Count;
//    EmployeeList resultList = new();
//    resultList.Employees = new();
//    int middle = length / 2;
//    int indexLow = 0;
//    int indexHigh;
//    int fakeLength;
//    bool loPass = false;
//    bool hiPass = false;
//    if (length % 2 != 0)
//    { middle += 1; }
//    int quarter = length / 2;
//    if (middle % 2 != 0)
//    { quarter += 1; }

//    int index = RecursiveBinary(searchList, low, indexLow);

//    if (low.CompareTo(DateTime.Parse(searchList.Employees[middle].LastExitFromEngineRoom)) < 0)
//    {
//        if (low.CompareTo(DateTime.Parse(searchList.Employees[quarter].LastExitFromEngineRoom)) <= 0)
//        {
//            for (int i = 0; i < quarter; i++)
//            {
//                if (low.CompareTo(DateTime.Parse(searchList.Employees[i].LastExitFromEngineRoom)) >= 0)
//                {
//                    indexLow = i;
//                    loPass = true;
//                }
//            }
//        }
//        if (loPass != true)
//        {
//            for (int i = quarter; i < middle; i++)
//            {
//                if (low.CompareTo(DateTime.Parse(searchList.Employees[i].LastExitFromEngineRoom)) >= 0)
//                {
//                    indexLow = i;
//                }
//            }
//        }
//    }
//    else if (low.CompareTo(DateTime.Parse(searchList.Employees[middle].LastExitFromEngineRoom)) >= 0)
//    {
//        if (low.CompareTo(searchList.Employees[middle + quarter].LastExitFromEngineRoom) >= 0)
//        {
//            for (int i = middle + quarter; i < length; i++)
//            {
//                if (low.CompareTo(DateTime.Parse(searchList.Employees[i].LastExitFromEngineRoom)) >= 0)
//                    indexLow = i - 1;
//                loPass = true;
//            }
//        }
//        if (loPass != true)
//        {
//            for (int i = middle; i < (middle + quarter); i++)
//            {
//                if (low.CompareTo(DateTime.Parse(searchList.Employees[i].LastExitFromEngineRoom)) >= 0)
//                    indexLow = i - 1;
//            }
//        }
//    }
//    else { return null; }

//    for (int i = indexLow; i < length; i++)
//    {
//        if (high.CompareTo(DateTime.Parse(searchList.Employees[i].LastExitFromEngineRoom)) > 0)
//        { break; }
//        else resultList.Employees.Add(searchList.Employees[i]);
//    }

//    return searchList;
//}


//if(length > 10 && !done)
//{
//    if (employees.Employees[quarter].parsedExit.CompareTo(low) < 0)
//    {
//        for (int i = 0; i < quarter; i++)
//        {
//            resultList.Employees.Add(employees.Employees[i]);
//        }
//        RecursiveBinary(resultList, low);
//        //low == median
//    }
//    else if (employees.Employees[quarter + middle].parsedExit.CompareTo(low) < 0)
//    {
//        for (int i = middle + quarter; i < employees.Employees.Count; i++)
//        {
//            resultList.Employees.Add(employees.Employees[i]);
//        }
//        RecursiveBinary(resultList, low);
//    }
//    else if (employees.Employees[middle].parsedExit.CompareTo(low) < 0)
//        Debug.Log(resultList.Employees.Count);

//}
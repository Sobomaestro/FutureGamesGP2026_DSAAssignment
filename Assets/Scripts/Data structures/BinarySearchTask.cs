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
            indexCutList.Employees = new();
            int[] indexArray = new int[2];
            midIndex = listToSearch.Employees.Count / 2;
            RecursiveBinary(listToSearch, lowSearchFloor);
            indexArray[0] = midIndex;
            for (int i = lowIndex; i < listToSearch.Employees.Count - 1; i++)
            {
                indexCutList.Employees.Add(listToSearch.Employees[i]);
            }
            midIndex = indexCutList.Employees.Count / 2;
            int listDelta = listToSearch.Employees.Count - indexCutList.Employees.Count;
            RecursiveBinary(indexCutList, highSearchRoof);            
            indexArray[1] = midIndex + listDelta;
            for ( int i = lowIndex; i < highIndex; i++)
            {
                indexCutList.Employees[i] = employees.Employees[i];
            }
            Debug.Log($"LowIndex is: {indexArray[0]} and highIndex is: {indexArray[1]}");
            return indexArray;
        }

        public void RecursiveBinary(EmployeeList employees, DateTime low)
        {
            int length = employees.Employees.Count;
            Debug.Log(length);
            EmployeeList resultList = new EmployeeList();
            int indexNo = 0;
            int middle = length / 2;
            if (length % 2 != 0)
            { middle += 1; }
            int quarter = middle / 2;
            if ( middle % 2 != 0)
            { quarter += 1; }                  
            if (employees.Employees.Count == 1)
            {
                 return;
            }
            //if (employees.Employees[middle].parsedExit == low)
            //{
            //    Console.WriteLine("the index for low is" + middle);
            //    return; 
            //}


            if(length > 1)
            {
                if (employees.Employees[middle].parsedExit.CompareTo(low) > 0)
                {
                    for (int i = 0; i < middle; i++)
                    {
                        resultList.Employees.Add(employees.Employees[i]);
                    }
                    midIndex -= middle / 2;
                    Debug.Log($"midIndex is {midIndex} ");
                    RecursiveBinary(resultList, low);
                }
                else 
                {
                    for (int i = middle; i < employees.Employees.Count - 1; i++)
                    {
                        resultList.Employees.Add(employees.Employees[i]);
                    }
                    midIndex += middle / 2;
                    Debug.Log($"midIndex is {midIndex} ");
                    RecursiveBinary(resultList, low);
                }
            }
            //resultList.Employees.AddRange(indexList.Employees, 0, 25);

            return;
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
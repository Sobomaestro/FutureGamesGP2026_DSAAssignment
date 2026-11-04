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
        
        public EmployeeList BinarySearchSpan (EmployeeList searchList, DateTime low, DateTime high)
        {
            int length = searchList.Employees.Count;
            EmployeeList resultList = new();
            resultList.Employees = new();
            int middle = length / 2;
            int indexLow = 0;
            int indexHigh;
            int fakeLength;
            bool loPass = false;
            bool hiPass = false;
            if (length % 2 != 0)
            { middle += 1; }
            int quarter = length / 2;
            if (middle % 2 != 0)
            { quarter += 1; }

            int index = RecursiveBinary(searchList, low, indexLow);

            if (low.CompareTo(DateTime.Parse(searchList.Employees[middle].LastExitFromEngineRoom)) < 0)
            {
                if (low.CompareTo(DateTime.Parse(searchList.Employees[quarter].LastExitFromEngineRoom)) <= 0)
                {
                    for (int i = 0; i < quarter; i++)
                    {
                        if (low.CompareTo(DateTime.Parse(searchList.Employees[i].LastExitFromEngineRoom)) >= 0)
                        {
                            indexLow = i;
                            loPass = true;
                        }
                    }
                }
                if (loPass != true)
                { 
                    for (int i = quarter; i < middle; i++)
                    {
                        if (low.CompareTo(DateTime.Parse(searchList.Employees[i].LastExitFromEngineRoom)) >= 0)
                        {
                            indexLow = i;
                        }
                    }
                }
            }
            else if (low.CompareTo(DateTime.Parse(searchList.Employees[middle].LastExitFromEngineRoom)) >= 0)
            {
                if (low.CompareTo(searchList.Employees[middle + quarter].LastExitFromEngineRoom) >= 0)
                {
                    for (int i = middle + quarter; i < length; i++)
                    {
                        if (low.CompareTo(DateTime.Parse(searchList.Employees[i].LastExitFromEngineRoom)) >= 0)
                        indexLow = i - 1;
                        loPass = true;
                    }
                }
                if (loPass != true)
                {
                    for (int i = middle; i < (middle + quarter); i++)
                    {
                        if (low.CompareTo(DateTime.Parse(searchList.Employees[i].LastExitFromEngineRoom)) >= 0)
                        indexLow = i - 1;
                    }
                }
            }
            else { return null; }

           for( int i = indexLow; i < length; i++)
            {
                if (high.CompareTo(DateTime.Parse(searchList.Employees[i].LastExitFromEngineRoom)) > 0)
                { break; }
                else resultList.Employees.Add(searchList.Employees[i]);
            }

            return searchList;
        }

        public int RecursiveBinary(EmployeeList indexList, DateTime low, int boi)
        {
            int length = indexList.Employees.Count;
            EmployeeList resultList = new EmployeeList();
            resultList.Employees = new();
            int indexNo = 0;
            int middle = length / 2;
            if (length %2 != 0)
            { middle += 1; }
            int quarter = middle / 2;
            if ( middle % 2 != 0)
            { quarter += 1; }

            if(length > 1)
            {
                if (indexList.Employees[quarter].parsedExit.CompareTo(low) < 0)
                { for(int i = }
                RecursiveBinary(resultList, low, indexNo);
            }
            resultList.Employees.AddRange(indexList.Employees, 0, 25);

            return indexNo;
        }
    }

}
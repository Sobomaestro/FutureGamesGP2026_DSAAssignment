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

        }
    }
}
using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;


namespace Environment.Tasks
{
    [CreateAssetMenu(fileName = "InteractableTasks", menuName = "Scriptable Objects/InteractableTasks")]

    public class InteractableTasks : Task
    {
        [SerializeField] private string taskDescription = "Sort the list of employees to find the suspect, and save the world.";
        [SerializeField] public TextAsset jsonFile;
        [SerializeField] public playerTaskManager taskManager;
        [SerializeField] SortTaskScript sortTask;
        [SerializeField] EmployeeList myEmployeeList;
        public Node root;
        [SerializeField] Task employeeSorter;
        JsonUI jsonUI;
        private string textToPrint = "Beep boop, computer sounds, a thousand modems singing in unison far, far away";
        public override void Execute()
        {
            myEmployeeList = new EmployeeList();
            myEmployeeList.Employees = new();
            myEmployeeList = JsonUtility.FromJson<EmployeeList>(jsonFile.text);
            for (int i = 0; i < myEmployeeList.Employees.Count; i++)
            { 
                myEmployeeList.Employees[i].Initialize(); 
            }
            jsonUI = FindAnyObjectByType<JsonUI>();
            jsonUI.PrintJson(myEmployeeList);
            for (int i = 0; i <= myEmployeeList.Employees.Count; ++i)
            {
                root = new Node(myEmployeeList.Employees[i]);
                TreeNode.Insert(root, myEmployeeList.Employees[i]);
            }
        }

        public void SortList()
        {
            sortTask.QuickerThanQuicksort(myEmployeeList, 0, myEmployeeList.Employees.Count - 1);
            jsonUI.PrintJson(myEmployeeList);
        }
        public EmployeeList ListSend()
        {
            return myEmployeeList;
        }
        public Node NodeSend()
        {
            return root;
        }
        public void PrintSearchSpan(int[] index)
        {
            jsonUI.PrintSearchSpan(myEmployeeList, index);
        }

    }

}
using UnityEngine;
using System.Collections;
using NUnit.Framework;
using System.IO;
using System;
using Unity.VisualScripting;

namespace Environment.Tasks {

    [CreateAssetMenu(fileName = "Jason", menuName = "Scriptable Objects/Jason")]
    public class Jason : Task {
        [SerializeField] private TextAsset jsonFile;
        [SerializeField] ScriptableObject jsonLoader;
        private Employees employees;
        private string textToPrint = "It's Json time";

        //EmployeeArray[] employeeData = new EmployeeArray[5];


        //string[] jsonData = Directory.GetFiles(Application.persistentDataPath, "*.json");
        public override void Execute(Task textToPrint) { Debug.Log(textToPrint); }

        //void LoadScore() {
        //    employeeData = JsonUtility.FromJson<EmployeeArray[]>(jsonFile.text);

        //    string name = employeeData.name;
        //    int employeeId = employeeData.employeeId;
        //    bool hasEngineRoomClearance = employeeData.hasEngineRoomClearance;
        //    DateTime lastEntranceInEngineRoom = employeeData.lastEntranceInEngineRoom;
        //    DateTime lastExitFromEngineRoom = employeeData.lastExitFromEngineRoom;
        //}
    }
}

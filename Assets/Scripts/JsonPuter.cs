using Environment;
using Environment.Tasks;
using UnityEngine;
using System.Collections.Generic;

public class JsonPuter : Computer, IInteractable
{
    public Employees employees;
    public TextAsset jsonFile;
    public EmployeeList myEmployeeList = new EmployeeList();
    public Employees[] employeebois = new Employees[5];
    string[] name = new string[5];
    int[] employeeID = new int[5];
    bool[] hasEngineRoomClearance = new bool[5];
    string[] lastEntranceInEngineRoom = new string[5];
    string[] lastExitFromEngineRoom = new string[5];
    //public List<EmployeeList> employeeData = new List<EmployeeList>();    
    


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public override void OnInteract()
    {
        myEmployeeList = JsonUtility.FromJson<EmployeeList>(jsonFile.text);
        foreach(employees in myEmployeeList)

        Debug.Log(myEmployeeList.ToString());
    }
    public void JsonIteration() {


    }
}

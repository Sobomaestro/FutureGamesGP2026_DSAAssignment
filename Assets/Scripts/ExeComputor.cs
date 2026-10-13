using Environment;
using Environment.Tasks;
using UnityEngine;

public class ExeComputor : Computer, IInteractable
{    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public override void OnInteract() {
        debugTasks.Execute(taskManager.playerTasks.Pop());
    }
}

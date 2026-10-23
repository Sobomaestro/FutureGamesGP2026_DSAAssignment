using Environment;
using Environment.Tasks;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class ExeComputor : Computer, IInteractable
{
    [SerializeField] Computer motherComputer;
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
        if (taskManager.playerTasks.Count > 0)
        {
            Task incomingTask = taskManager.TaskPeeker();
            if (incomingTask is DebugPrintTask debugTask)
            {
                taskManager.TaskExecutor();
                incomingTask.Execute();
                debugTasks.Execute();
            }         
            else if (incomingTask is InteractableTasks interactTask)
            { Debug.Log("This task needs a stronger workstation than this..."); }
        }
        
        else if (taskManager.playerTasks.Count == 0 && motherComputer.listOfDoodoo.Count > 0)
        {
            Debug.Log("there is yet stuff to be done");
            taskManager.LazyTasker();
        }
        else
        {
            Debug.Log("nothing to execute, my liege");
            taskManager.UpdateTask(null);
            taskManager.LerpReset();
        }

    }
}

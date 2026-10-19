using Environment.Tasks;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Unity.VisualScripting;
using UnityEngine;
namespace Environment
{
    
    public class Trashcan : MonoBehaviour, IInteractable
    {
        [SerializeField] public playerTaskManager taskManager;

        public virtual void OnInteract(){
            taskManager.IThrewItOnTheGround();
        }
    }
}

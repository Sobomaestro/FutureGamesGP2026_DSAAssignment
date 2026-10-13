using UnityEngine;
using System.Collections;
using NUnit.Framework;

namespace Environment.Tasks
{
    [CreateAssetMenu(fileName = "Tasks", menuName = "DebugPrint Task")]
    public class DebugPrintTask : Task
    {
        [SerializeField]
        private string textToPrint = "dö";
        

        public override void Execute()
        {
            Debug.Log(textToPrint);
        }
    }
}

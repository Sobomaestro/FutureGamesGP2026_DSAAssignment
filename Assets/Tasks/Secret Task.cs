using NUnit.Framework;
using System.Threading.Tasks;
using UnityEngine;
using System.Collections.Generic;
using UnityEditor.TerrainTools;

namespace Environment.Tasks
{
    [CreateAssetMenu(fileName = "SecretTask", menuName = "Scriptable Objects/SecretTask")]
    public class SecretTask : Task
    {
        int index = 0;
        public override void Execute()
        {
            List<int> secretList = new List<int>() { 8, 2, 1, 3, 9 };
            PrintList(secretList);
            SortMySecretListBruv(secretList, index);
        }
        void PrintList(List<int> secretList)
        {
            for (int i = 0; i < secretList.Count; i++)
            {
                Debug.Log("index " + i + " of my secret list is: " + secretList[i] + "\r\n");
                
            }
            Debug.Log(secretList[0] + " " + secretList[1] + " " + secretList[2] + " " + secretList[3] + " " + secretList[4]);
            Debug.Log("________________________________________");
        }
        void SortMySecretListBruv(List<int> secretList, int index)
        {            
            for (int i = 0; i < secretList.Count; i++)
            {
                if (index > 0)
                { index = IndexReset(index); }
                for (; index < secretList.Count - 1; index++)
                {
                    if (secretList[index] > secretList[index + 1])
                    {
                        int temp = secretList[index + 1];
                        secretList[index + 1] = secretList[index];
                        secretList[index] = temp;
                    }
                }
                PrintList(secretList);
            }
        }
        int IndexReset(int index)
        {
            int temp = 0;
             for (; 0 < index; index--)
             {
                temp += index;
                Debug.Log("index is currently: " + index);
             }
            Debug.Log("index value removed from the world: " + temp);
            if (index == 0)
            { return index; }
            else { index = 0;  return index; }
        }
    }
}
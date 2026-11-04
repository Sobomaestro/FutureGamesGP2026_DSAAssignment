using System.Collections.Generic;
using UnityEngine;


namespace Utils
{

    public class MorshMaps : MonoBehaviour
    {

        private List<int>[] hashMap;

        public MorshMaps()
        {
            hashMap = new[] { new List<int>() };
        }

        private static int ComputeHash(int valueToHash, int hashMapLength)
        {
            if (hashMapLength == 0)
            {
                return -1;
            }
            return valueToHash % hashMapLength;
        }

        public void Put(int inNewValue)
        {
            int hash = ComputeHash(inNewValue, hashMap.Length);

            // if bucket is empty
            if (hashMap[hash].Count == 0)
            {
                hashMap[hash].Add(inNewValue);
            }
            else
            {
                int i;
                for (i = 0; i < hashMap[hash].Count; i++)
                {

                }
                hashMap[hash][i] = inNewValue;
            }
        }

        public int Get(int inValueToSearch)
        { // do at home as an excercise            
            int hashIndex = ComputeHash(inValueToSearch, hashMap.Length);
            for (int i = 0; i < hashMap[hashIndex].Count; i++)
            {
                if (hashMap[hashIndex][i] == inValueToSearch)
                { return hashMap[hashIndex][i]; }
            }
            Debug.Log("no valid entries matching your search");
            return -1;
        }

    }
}
 


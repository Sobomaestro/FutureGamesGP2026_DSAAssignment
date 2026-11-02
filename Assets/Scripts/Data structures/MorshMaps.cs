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

        private static int computeHash(int valueToHash, int hashMapLength)
        {
            if (hashMapLength == 0)
            {
                return -1;
            }
            return valueToHash % hashMapLength;
        }

        public void put(int inNewValue)
        {
            int hash = computeHash(inNewValue, hashMap.Length);

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

        public int get(int inValueToSearch)
        { // do at home as an excercise
            return -1;
        }

    }
}
 


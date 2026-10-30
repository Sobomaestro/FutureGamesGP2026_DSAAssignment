using UnityEngine;

public class EmployeeMerge : MonoBehaviour
{
    public void DecapiSort(int[] array)
    {
        int length = array.Length;
        int middle = length / 2;
        if (length <= 1) { return; }
        int[] leftArray = new int[middle];
        int[] rightArray = new int[length - middle];

        int i = 0; //left array
        int j = 0; //right array

        for (; i < length; i++)
        {
            if (i < middle)
            {
                leftArray[i] = array[i];
            }
            else
            {
                rightArray[j] = array[i];
                j++;
            }
        }
        DecapiSort(leftArray);
        DecapiSort(rightArray);
        FrankenSort(leftArray, rightArray, array);
    }
    public void FrankenSort(int[] leftArray, int[] rightArray, int[] array)
    {
        int middle = leftArray.Length + (rightArray.Length - leftArray.Length) / 2;
        int leftSize = array.Length / 2;
        int rightSize = array.Length - leftSize;
        int i = 0, l = 0, r = 0;

        while (l < leftSize && r < rightSize)
        {
            if (leftArray[l] < rightArray[r])
            {
                array[i] = leftArray[l];
                i++; l++;
            }
            else
            {
                array[i] = rightArray[r];
                i++; r++;
            }
        }
        while (l < leftSize)
        {
            array[i] = leftArray[l];
            i++; l++;
        }
        while (r < rightSize)
        {
            array[i] = rightArray[r];
            i++; r++;
        }
    }
}

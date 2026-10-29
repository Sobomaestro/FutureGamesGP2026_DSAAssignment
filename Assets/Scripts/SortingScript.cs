using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.UIElements;
using Unity.VisualScripting;

public class SortingScript : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI generatedNumber;

    [SerializeField] Transform parent;
    [SerializeField] VerticalLayoutGroup Contentbox;    
    [SerializeField] UnityEngine.UI.Button sortBtn;
    [SerializeField] UnityEngine.UI.Button genBtn;
    bool generated = false;
    int[] randomNumberArray = new int[100];
    TextMeshProUGUI[] numberBox = new TextMeshProUGUI[100];

    public void Awake()
    {        
        
    }

    public void RandomNumberArrayer()
    {
        
        for (int i = 0; i < 99; i++)
        {
            int randomNumber = Random.Range(0, 100);
            randomNumberArray[i] = randomNumber;
            if (!generated)
            {
                numberBox[i] = Instantiate(generatedNumber, transform.position, Quaternion.identity, parent);
                numberBox[i].name = "numberBox" + i;
            }
            numberBox[i].text = randomNumberArray[i].ToString();
        }
        generated = true;
        Debug.Log(randomNumberArray.Length);
    }

    public void ButtonClick()
    {
        DecapiSort(randomNumberArray);
        for (int i = 0; i < randomNumberArray.Length - 1;i++)
        {
            numberBox[i].text = randomNumberArray[i].ToString();
        }
    }

    public void DecapiSort(int[] array)
    {
        int length = array.Length;
        int middle = length / 2;
        if (length <= 1) { return; }
        int[] leftArray = new int[middle];
        int[] rightArray = new int[length - middle];

        int i = 0; //left array
        int j = 0; //right array

        for(; i < length; i++)
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



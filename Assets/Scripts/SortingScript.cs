using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.UIElements;
using Unity.VisualScripting;

public class SortingScript : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI generatedNumber;
    [SerializeField] TextMeshProUGUI[] numberBox = new TextMeshProUGUI[20];
    [SerializeField] Transform parent;
    [SerializeField] VerticalLayoutGroup Contentbox;
    [SerializeField] List<TextMeshProUGUI> boxList = new List<TextMeshProUGUI>();
    [SerializeField] UnityEngine.UI.Button sortBtn;
    [SerializeField] UnityEngine.UI.Button genBtn;
    int[] randomNumberArray;
    
    void Awake()
    {
        
    }

    public void RandomNumberArrayer()
    {
        int[] randomNumberArray = new int[20];
        for (int i = 0; i < randomNumberArray.Length; i++)
            {              
                int randomNumber = Random.Range(0, 100);
                randomNumberArray[i] = randomNumber;     
                numberBox[i] = Instantiate(generatedNumber, transform.position, Quaternion.identity, parent);
                numberBox[i].name = "numberBox" + i;
                numberBox[i].text = randomNumber.ToString();
                boxList.Add(numberBox[i]);
            }      
    }

    public void ButtonClick()
    {

    }

    public void ArraySorter()
    {
        {            
            for (int i = 0; i < boxList.Count -1; i++)
            {
                for (int j = i + 1; j < boxList.Count; j++)
                {
                    if (int.Parse(boxList[i].text) > int.Parse(boxList[j].text))
                    {
                        int temp = int.Parse(boxList[j].text);
                        boxList[j].text = boxList[i].text;
                        boxList[i].text = temp.ToString();
                        numberBox[i].text = temp.ToString();
                    }
                }                
            }
        }
    }


}

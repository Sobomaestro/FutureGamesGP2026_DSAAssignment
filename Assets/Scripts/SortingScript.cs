using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.UIElements;
using Unity.VisualScripting;

public class SortingScript : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI generatedNumber;
    TextMeshProUGUI[] numberBox = new TextMeshProUGUI[20];
    [SerializeField] Transform parent;
    [SerializeField] VerticalLayoutGroup Contentbox;
    [SerializeField] List<TextMeshProUGUI> boxList = new List<TextMeshProUGUI>();
    [SerializeField] UnityEngine.UI.Button sortBtn;
    [SerializeField] UnityEngine.UI.Button genBtn;
    bool generated = false;
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
            if (!generated)
            {
                numberBox[i] = Instantiate(generatedNumber, transform.position, Quaternion.identity, parent);
                numberBox[i].name = "numberBox" + i;
                
            }
                numberBox[i].text = randomNumber.ToString();
                //boxList.Add(numberBox[i]);
            }
        generated = true;
        //genBtn.interactable = false;
    }

    public void ButtonClick()
    {

    }

    public void ArraySorter()
    {
        {            
            for (int i = 0; i < numberBox.Length -1; i++)
            {
                for (int j = i + 1; j < numberBox.Length; j++)
                {
                    if (int.Parse(numberBox[i].text) > int.Parse(numberBox[j].text))
                    {
                        int temp = int.Parse(numberBox[j].text);
                        numberBox[j].text = numberBox[i].text;
                        numberBox[i].text = temp.ToString();
                        numberBox[i].text = temp.ToString();
                    }
                }                
            }
        }
    }


}

using Environment.Tasks;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class searchMenuUI : MonoBehaviour
{
    #region SerializedFields
    [SerializeField] TMP_InputField lowYearTbx;
    [SerializeField] TMP_InputField lowMonthTbx;
    [SerializeField] TMP_InputField lowDayTbx;
    [SerializeField] TMP_InputField lowHourTbx;
    [SerializeField] TMP_InputField lowMinuteTbx;
    [SerializeField] TMP_InputField lowSecondTbx;
    [SerializeField] TMP_InputField highYearTbx;
    [SerializeField] TMP_InputField highMonthTbx;
    [SerializeField] TMP_InputField highDayTbx;
    [SerializeField] TMP_InputField highHourTbx;
    [SerializeField] TMP_InputField highMinuteTbx;
    [SerializeField] TMP_InputField highSecondTbx;
    [SerializeField] public TextMeshProUGUI errorBox;
    [SerializeField] public CanvasGroup searchMenu;
    [SerializeField] SearchSpanParser searchSpan;
    [SerializeField] BinarySearchTask binarySearch;
    [SerializeField] InteractableTasks jsonList;
    #endregion
    bool validDateTime;
    DateTime spanFloor;
    DateTime spanCeiling;
    int[] indexLowHigh = new int[2];


    public void CloseSearchWindow()
    {
        searchMenu.interactable = false;
        searchMenu.alpha = 0;
        searchMenu.blocksRaycasts = false;
    }

    public void Search()
    { 
        CheckDates(lowYearTbx.text, lowMonthTbx.text, lowDayTbx.text);
        
        if (validDateTime)
        { spanFloor = DateTime.Parse(lowYearTbx.text + "-" + lowMonthTbx.text + "-" + lowDayTbx.text + "T" + lowHourTbx.text + ":" + lowMinuteTbx.text + ":" + lowSecondTbx.text); }
        else { errorBox.text = "Low date is not valid, check your entries";  return; }

        CheckDates(highYearTbx.text, highMonthTbx.text, highDayTbx.text);
        if (validDateTime)
        { spanCeiling = DateTime.Parse(highYearTbx.text + "-" + highMonthTbx.text + "-" + highDayTbx.text + "T" + highHourTbx.text + ":" + highMinuteTbx.text + ":" + highSecondTbx.text); }
        else { errorBox.text = "High date is not valid, check your entries"; return; }

        EmployeeList searchList = jsonList.ListSend();
        indexLowHigh = binarySearch.IntakeSearchData(searchList, spanFloor, spanCeiling);
        for (int i = indexLowHigh[0]; i <= indexLowHigh[1]; i++)
        {
            Debug.Log($"index {i} in span of search {searchList.Employees[i]}");
        }
    }

    void CheckDates(string year, string month, string day)
    {
        Debug.Log(year + month + day);
        int yearInt = int.Parse(year);
        
        int monthInt = int.Parse(month);
        int dayInt = int.Parse(day);
        validDateTime = searchSpan.CheckMonths(yearInt, monthInt, dayInt);
        Debug.Log(year + month + day);
    }

}

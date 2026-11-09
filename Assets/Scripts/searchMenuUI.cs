using Environment.Tasks;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Diagnostics;

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
    [SerializeField] InteractableTasks jsonHolder;
    JsonUI jsonUI;


    public void CloseSearchWindow()
    {
        searchMenu.interactable = false;
        searchMenu.alpha = 0;
        searchMenu.blocksRaycasts = false;
    }

    public void Search()
    {
        var sw2 = new Stopwatch();
        sw2.Start();
        CheckDates(lowYearTbx.text, lowMonthTbx.text, lowDayTbx.text);
        var sw = new Stopwatch();
        
        if (validDateTime)
        { spanFloor = DateTime.Parse(lowYearTbx.text + "-" + lowMonthTbx.text + "-" + lowDayTbx.text + "T" + lowHourTbx.text + ":" + lowMinuteTbx.text + ":" + lowSecondTbx.text); }
        else { errorBox.text = "Low date is not valid, check your entries";  return; }

        CheckDates(highYearTbx.text, highMonthTbx.text, highDayTbx.text);
        if (validDateTime)
        { spanCeiling = DateTime.Parse(highYearTbx.text + "-" + highMonthTbx.text + "-" + highDayTbx.text + "T" + highHourTbx.text + ":" + highMinuteTbx.text + ":" + highSecondTbx.text); }
        else { errorBox.text = "High date is not valid, check your entries"; return; }

        EmployeeList searchList = jsonList.ListSend();
        sw.Start();
        indexLowHigh = binarySearch.IntakeSearchData(searchList, spanFloor, spanCeiling);
        sw.Stop();
        UnityEngine.Debug.Log("Search right before and after the actual search took: " + sw.ElapsedTicks + " Ticks");
        jsonList.PrintSearchSpan(indexLowHigh);
        sw2.Stop();
        UnityEngine.Debug.Log("Entire search task took around: " + sw2.ElapsedTicks + " Ticks");
    }

    void CheckDates(string year, string month, string day)
    {
        int yearInt = int.Parse(year);
        int monthInt = int.Parse(month);
        int dayInt = int.Parse(day);
        validDateTime = searchSpan.CheckMonths(yearInt, monthInt, dayInt);
    }

}

using System.Collections;
using System.Reflection.Metadata.Ecma335;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "SearchSpanParser", menuName = "Scriptable Objects/SearchSpanParser")]


public class SearchSpanParser : ScriptableObject
{


    //gör en fet switchcase med månader som innehåller dagar osv. kasta errors på användare.
    int inputMonth;
    int inputDay;
    public bool CheckMonths(int year, int month, int day)
    {
        bool validDate = true;
        bool leapYear = false;
        int errorMonth = 0;
        int errorDays = 1;
        int daysInMonth = 0;

        if (year % 100 == 0 && year % 400 == 0)
        { leapYear = true; }
        else { leapYear = false; }

        if (month == 1|| month == 3|| month == 5|| month == 7|| month == 8|| month == 10|| month == 12)
        { daysInMonth = 31; }
        else if (month == 4|| month == 6|| month == 9|| month == 11)
        { daysInMonth = 30; }
        else if (month == 2 && !leapYear)
        {  daysInMonth = 28; }
        else if (month == 2 && leapYear)
        { daysInMonth = 29; }
        else { ErrorThrower(errorMonth); validDate = false; }


        switch(daysInMonth)
        {
            case 31:
                if (day > 31)
                { ErrorThrower(errorDays); validDate = false; }
                break;
            case 30:
                if(day > 30)
                {  ErrorThrower(errorDays); validDate = false; }
                break;
            case 28:
                if(day > 28)
                { ErrorThrower(errorDays); validDate = false; }
                break;
            case 29:
                if(day > 29)
                { ErrorThrower(errorDays); validDate = false; }
                break;
        }
        return validDate;
    }
    
    void ErrorThrower(int errorCode)
    {
        searchMenuUI searchMenu = FindAnyObjectByType<searchMenuUI>();
        switch(errorCode)
        {
            case 0:
                searchMenu.errorBox.text = "The month you tried to enter does not exist";
                break;
            case 1:
                searchMenu.errorBox.text = "Exceeded the amount of days in the month you entered";
                break;
        }
    }

}
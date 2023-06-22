using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using Unity.VisualScripting;

public class Calendar : MonoBehaviour
{
    #region Calendar
    public class Day
    {
        public int dayNum;
        public Color dayColor;
        public GameObject obj;



        public Day(int dayNum, Color dayColor, GameObject obj)
        {
            this.dayNum = dayNum;
            this.obj = obj;
            UpdateColor(dayColor);
            UpdateDay(dayNum);
        }


        public void UpdateColor(Color newColor)
        {
            obj.GetComponent<Image>().color = newColor;
            dayColor = newColor;
        }


        public void UpdateDay(int newDayNum)
        {
            this.dayNum = newDayNum;
            if (dayColor == Color.black || dayColor == Color.magenta)
            {
                obj.GetComponentInChildren<Text>().text = (dayNum + 1).ToString();
            }
            else
            {
                obj.GetComponentInChildren<Text>().text = "";
            }
        }
    }

    public void UpdateColorForDayOfWeek(DayOfWeek dayOfWeek, Color newColor)
    {
        for (int i = 0; i < days.Count; i++)
        {
            if ((int)currDate.AddDays(days[i].dayNum).DayOfWeek == (int)dayOfWeek)
            {
                days[i].UpdateColor(newColor);
            }
        }
    }

    public void ResetColors()
    {
        for (int i = 0; i < days.Count; i++)
        {
            if (days[i].dayColor != Color.magenta)
            {
                days[i].UpdateColor(Color.black);
            }
        }
    }

    private List<Day> days = new List<Day>();


    public Transform[] weeks;


    public Text MonthAndYear;


    public DateTime currDate = DateTime.Now;


    

    
    void UpdateCalendar(int year, int month)
    {
        DateTime temp = new DateTime(year, month, 1);
        currDate = temp;
        MonthAndYear.text = temp.ToString("MMMM") + " " + temp.Year.ToString();
        int startDay = GetMonthStartDay(year, month) - 1;
        int endDay = GetTotalNumberOfDays(year, month);




        if (days.Count == 0)
        {
            for (int w = 0; w < 6; w++)
            {
                for (int i = 0; i < 7; i++)
                {
                    Day newDay;
                    int currDay = (w * 7) + i;
                    if (currDay < startDay || currDay - startDay >= endDay)
                    {
                        newDay = new Day(currDay - startDay, Color.grey, weeks[w].GetChild(i).gameObject);
                    }
                    else
                    {
                        newDay = new Day(currDay - startDay, Color.black, weeks[w].GetChild(i).gameObject);
                    }
                    days.Add(newDay);
                }
            }
        }

        else
        {
            for (int i = 0; i < 42; i++)
            {
                if (i < startDay || i - startDay >= endDay)
                {
                    days[i].UpdateColor(Color.grey);
                }
                else
                {
                    days[i].UpdateColor(Color.black);
                }

                days[i].UpdateDay(i - startDay);
            }
        }


        if (DateTime.Now.Year == year && DateTime.Now.Month == month)
        {
            days[(DateTime.Now.Day - 1) + startDay].UpdateColor(Color.magenta);
        }

    }


    int GetMonthStartDay(int year, int month)
    {
        DateTime temp = new DateTime(year, month, 1);

        //DayOfWeek Monday == 0, Sunday == 6 etc.
        return (int)temp.DayOfWeek;
    }


    int GetTotalNumberOfDays(int year, int month)
    {
        return DateTime.DaysInMonth(year, month);
    }


    public void SwitchMonth(int direction)
    {
        if (direction < 0)
        {
            currDate = currDate.AddMonths(-1);
        }
        else
        {
            currDate = currDate.AddMonths(1);
        }

        UpdateCalendar(currDate.Year, currDate.Month);
    }
    #endregion Calendar

    #region Weaks
    private void Start()
    {
        UpdateCalendar(DateTime.Now.Year, DateTime.Now.Month);
        MondayToggle.onValueChanged.AddListener(delegate { OnMondayToggleValueChanged(); });
        TuesdayToggle.onValueChanged.AddListener(delegate { OnTuesdayToggleValueChanged(); });
        WednesdayToggle.onValueChanged.AddListener(delegate { OnWednesdayToggleValueChanged(); });
        ThursdayToggle.onValueChanged.AddListener(delegate { OnThursdayToggleValueChanged(); });
        FridayToggle.onValueChanged.AddListener(delegate { OnFridayToggleValueChanged(); });
        SaturdayToggle.onValueChanged.AddListener(delegate { OnSaturdayToggleValueChanged(); });
        SundayToggle.onValueChanged.AddListener(delegate { OnSundayToggleValueChanged(); });
    }

    public Toggle MondayToggle;
    public Toggle TuesdayToggle;
    public Toggle WednesdayToggle;
    public Toggle ThursdayToggle;
    public Toggle FridayToggle;
    public Toggle SaturdayToggle;
    public Toggle SundayToggle;

    public void OnMondayToggleValueChanged()
    {
        if (MondayToggle.isOn)
        {
            UpdateColorForDayOfWeek(DayOfWeek.Monday, Color.red);
        }
        else
        {
            ResetColors();
        }
    }

    public void OnTuesdayToggleValueChanged()
    {
        if (TuesdayToggle.isOn)
        {
            UpdateColorForDayOfWeek(DayOfWeek.Tuesday, Color.red);
        }
        else
        {
            ResetColors();
        }
    }

    public void OnWednesdayToggleValueChanged()
    {
        if (WednesdayToggle.isOn)
        {
            UpdateColorForDayOfWeek(DayOfWeek.Wednesday, Color.red);
        }
        else
        {
            ResetColors();
        }
    }

    public void OnThursdayToggleValueChanged()
    {
        if (WednesdayToggle.isOn)
        {
            UpdateColorForDayOfWeek(DayOfWeek.Thursday, Color.red);
        }
        else
        {
            ResetColors();
        }
    }

    public void OnFridayToggleValueChanged()
    {
        if (WednesdayToggle.isOn)
        {
            UpdateColorForDayOfWeek(DayOfWeek.Friday, Color.red);
        }
        else
        {
            ResetColors();
        }
    }

    public void OnSaturdayToggleValueChanged()
    {
        if (WednesdayToggle.isOn)
        {
            UpdateColorForDayOfWeek(DayOfWeek.Saturday, Color.red);
        }
        else
        {
            ResetColors();
        }
    }

    public void OnSundayToggleValueChanged()
    {
        if (MondayToggle.isOn)
        {
            UpdateColorForDayOfWeek(DayOfWeek.Sunday, Color.red);
        }
        else
        {
            ResetColors();
        }
    }
}
#endregion Weaks

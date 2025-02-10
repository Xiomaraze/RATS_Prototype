using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameTime : MonoBehaviour
{
    public GameObject clockHUDObject;
    public Canvas canvas;
    TextMeshProUGUI clockText;
    CurrentTime currentHour;
    public GameObject tempDay; //switches to night at 5 pm
    public GameObject tempNight;//switches to day at 10 pm



    enum CurrentTime {Noon, One, Two, Three, Four, Five, Six, Seven, Eight, Nine, Ten, ResetHour};

    // Start is called before the first frame update
    void Start()
    {
        currentHour = CurrentTime.Noon;
        clockText = clockHUDObject.GetComponent<TextMeshProUGUI>();
    }

    public void XHoursLater(int hours)
    {
        switch (hours)
        {
            case 1:
                if (currentHour == CurrentTime.Five)
                {
                    tempDay.SetActive(false);
                    tempNight.SetActive(true);
                }
                else if (currentHour == CurrentTime.Ten)
                {
                    tempNight.SetActive(false);
                    tempDay.SetActive(true);
                }
                currentHour = currentHour + 1;
                break;
            case 4:
                int passageHolder = 4;
                if (currentHour == CurrentTime.Six)
                {
                    tempNight.SetActive(false);
                    tempDay.SetActive(true);
                    currentHour = CurrentTime.Noon;
                    passageHolder = 0;
                }
                else if (currentHour > CurrentTime.Six) 
                {
                    int hoursLeft = 10;
                    hoursLeft = hoursLeft - ((int)currentHour);
                    passageHolder = passageHolder - hoursLeft;
                    currentHour = CurrentTime.Noon;
                }
                else if (currentHour >= CurrentTime.Two)
                {
                    tempDay.SetActive(false);
                    tempNight.SetActive(true);
                }
                currentHour += passageHolder;
                break;
        }
    }

    public DaySlot.hour WhatTimeIsIt()
    {
        if ((currentHour >= CurrentTime.Noon) && (currentHour < CurrentTime.Three))
        {
            return DaySlot.hour.EarlyDay;
        }
        else if ((currentHour >= CurrentTime.Three) && (currentHour < CurrentTime.Five))
        {
            return DaySlot.hour.LateDay;
        }
        else if ((currentHour >= CurrentTime.Five) && (currentHour < CurrentTime.Seven))
        {
            return DaySlot.hour.EarlyNight;
        }
        else
        {
            return DaySlot.hour.LateNight;
        }
    }

    void HourManagement()
    {
        switch (currentHour) //this will handle active changes between hours
        {
            case CurrentTime.Noon:
                break;
            case CurrentTime.One:
                break;
            case CurrentTime.Two:
                break;
            case CurrentTime.Three:
                break;
            case CurrentTime.Four:
                break;
            case CurrentTime.Five:
                break;
            case CurrentTime.Six:
                break;
            case CurrentTime.Seven:
                break;
            case CurrentTime.Eight:
                break;
            case CurrentTime.Nine:
                break;
            case CurrentTime.Ten:
                break;
            case CurrentTime.ResetHour:
                break;
        }
        clockText.text = currentHour.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        HourManagement();
    }
}

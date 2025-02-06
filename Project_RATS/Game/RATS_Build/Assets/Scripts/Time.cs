using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Time : MonoBehaviour
{
    public GameObject playerHUD;
    public Canvas canvas;
    TextMeshProUGUI clockText;
    CurrentTime hour;
    //DayNight background;
    public bool day;
    public bool night;
    public GameObject tempDay; //switches to night at 5 pm
    public GameObject tempNight;

    enum DayNight { Day, Night }
    enum CurrentTime {Noon, One, Two, Three, Four, Five, Six, Seven, Eight, Nine, Ten};
    // Start is called before the first frame update
    void Start()
    {
        hour = CurrentTime.Noon;
        clockText = playerHUD.GetComponent<TextMeshProUGUI>();
        //npcDialogue = NPC.GetComponent<DialogueSystem>();
        //background = DayNight.Day;
    }

    public void XHoursLater (int hours)
    {
        switch (hours)
        {
            case 1:
                if (hour == CurrentTime.Four)
                {
                    hour = hour + 1;
                }
                else if (hour == CurrentTime.Ten)
                {
                    hour = 0;
                }
                break;
            case 4:
                if (hour >= CurrentTime.Six)
                {
                    switch (hour)
                    {
                        case CurrentTime.Six:
                            hour = CurrentTime.Noon;
                            break;
                        case CurrentTime.Seven:
                            hour = CurrentTime.One;
                            break;
                        case CurrentTime.Eight:
                            hour = CurrentTime.Two;
                            break;
                        case CurrentTime.Nine:
                            hour = CurrentTime.Three;
                            break;
                        case CurrentTime.Ten:
                            hour = CurrentTime.Four;
                            break;
                    }
                }
                else
                {
                    hour = hour + 4;
                }
                break;
        }
    }

    void HourManagement()
    {
        if (hour < CurrentTime.Five)
        {
            tempDay.SetActive(true);
            tempNight.SetActive(false);
        }
        else
        {
            tempDay.SetActive(false);
            tempNight.SetActive(true);
        }
        switch (hour)
        {
            case CurrentTime.Noon:
                //stuff
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
        }
        clockText.text = hour.ToString();
    }

    public int WhatTime()
    {
        if (hour < CurrentTime.Three)
        {
            return 0;
        }
        else if (hour < CurrentTime.Five)
        {
            return 1;
        }
        else if (hour < CurrentTime.Seven)
        {
            return 2;
        }
        else
        {
            return 3;
        }
    }
    DayNight dayOrNight()
    {
        if (hour <= CurrentTime.Five)
        {
            return DayNight.Day;
        }
        else
        {
             return DayNight.Night;
        }
    }


    // Update is called once per frame
    void Update()
    {
        HourManagement();
    }
}

    //sad dead code below here, this is the fossil storage

    //void HourManagement ()
    //{
    //switch (hour) //this will handle active changes between hours
    //{
    //    case CurrentTime.EightAM:
    //        day = true;
    //        night = false;
    //        dusk = false;
    //        break;
    //    case CurrentTime.NineAM:
    //        day = true;
    //        night = false;
    //        dusk = false;
    //        break;
    //    case CurrentTime.TenAM:
    //        day = true;
    //        night = false;
    //        dusk = false;
    //        break;
    //    case CurrentTime.ElevenAM:
    //        day = true;
    //        night = false;
    //        dusk = false;
    //        break;
    //    case CurrentTime.Noon:
    //        day = true;
    //        night = false;
    //        dusk = false;
    //        break;
    //    case CurrentTime.OnePM:
    //        day = true;
    //        night = false;
    //        dusk = false;
    //        break;
    //    case CurrentTime.TwoPM:
    //        day = true;
    //        night = false;
    //        dusk = false;
    //        break;
    //    case CurrentTime.ThreePM:
    //        day = true;
    //        night = false;
    //        dusk = false;
    //        break;
    //    case CurrentTime.FourPM:
    //        day = true;
    //        night = false;
    //        dusk = false;
    //        break;
    //    case CurrentTime.FivePM:
    //        day = false;
    //        dusk = true;
    //        night = false;
    //        break;
    //    case CurrentTime.SixPM:
    //        day = false;
    //        dusk = true;
    //        night = false;
    //        break;
    //    case CurrentTime.SevenPM:
    //        day = false;
    //        dusk = true;
    //        night = false;
    //        break;
    //    case CurrentTime.EightPM:
    //        day = false;
    //        dusk = false;
    //        night = true;
    //        break;
    //    case CurrentTime.NinePM:
    //        day = false;
    //        dusk = false;
    //        night = true;
    //        break;
    //    case CurrentTime.TenPM:
    //        day = false;
    //        dusk = false;
    //        night = true;
    //        break;
    //    case CurrentTime.ElevenPM:
    //        day = false;
    //        dusk = false;
    //        night = true;
    //        break;
    //    case CurrentTime.Midnight: //this is specifically if we want to have some sort of animation to indicate a clock reset
    //        day = false;
    //        dusk = false;
    //        night = true;
    //        break;
    //}
    //    clockText.text = hour.ToString();
    //}
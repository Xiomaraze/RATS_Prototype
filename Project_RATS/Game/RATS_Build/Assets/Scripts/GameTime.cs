using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameTime : MonoBehaviour
{
    public GameObject hudClockObject;
    public Canvas canvas;
    TextMeshProUGUI clockText;
    CurrentTime hour;
    public GameObject tempDay; //switches to night at 5 pm
    public GameObject tempNight;


    enum CurrentTime { Noon, One, Two, Three, Four, Five, Six, Seven, Eight, Nine, Ten, ResetHour }
    //enum CurrentTime { EightAM, NineAM, TenAM, ElevenAM, Noon, OnePM, TwoPM, ThreePM, FourPM, FivePM, SixPM, SevenPM, EightPM, NinePM, TenPM, ElevenPM, Midnight };
    // Start is called before the first frame update
    void Start()
    {
        hour = CurrentTime.Noon;
        clockText = hudClockObject.GetComponent<TextMeshProUGUI>();
    }

    public void XHoursLater(int hours)
    {
        switch (hours)
        {
            case 1:
                if (hour == CurrentTime.Five)
                {
                    tempDay.SetActive(false);
                    tempNight.SetActive(true);
                }
                else if (hour == CurrentTime.Ten)
                {
                    tempNight.SetActive(false);
                    tempDay.SetActive(true);
                }
                hour = hour + 1;
                break;
            case 4:
                int tempHolder = 4;
                if (hour > CurrentTime.Six)
                {
                    tempNight.SetActive(false);
                    tempDay.SetActive(true);
                    int tempHour = 10 - ((int)hour);
                    tempHolder = tempHolder - tempHour;
                    hour = CurrentTime.Noon;
                }
                else if (hour <= CurrentTime.Six && hour > CurrentTime.One)
                {
                    tempNight.SetActive(true);
                    tempDay.SetActive(false);
                }
                hour = hour + tempHolder;
                break;
        }
    }

    void HourManagement()
    {
        switch (hour) //this will handle active changes between hours
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
            case CurrentTime.ResetHour: //this is specifically if we want to have some sort of animation to indicate a clock reset
                hour = CurrentTime.Noon;
                break;
        }
        clockText.text = hour.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        HourManagement();
    }
}

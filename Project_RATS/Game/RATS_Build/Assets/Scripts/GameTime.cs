using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameTime : MonoBehaviour
{
    public GameObject hudClockObject;
    public Canvas canvas;
    TextMeshProUGUI clockText;
    CurrentTime currentHour;
    public GameObject tempDay; //switches to night at 5 pm
    public GameObject tempNight;


    enum CurrentTime {Noon, One, Two, Three, Four, Five, Six, Seven, Eight, Nine, Ten, ResetHour}
    //enum CurrentTime { EightAM, NineAM, TenAM, ElevenAM, Noon, OnePM, TwoPM, ThreePM, FourPM, FivePM, SixPM, SevenPM, EightPM, NinePM, TenPM, ElevenPM, Midnight };
    // Start is called before the first frame update
    void Start()
    {
        currentHour = CurrentTime.Noon;
        clockText = hudClockObject.GetComponent<TextMeshProUGUI>();
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
                int tempPassage = 4;
                if (currentHour >= CurrentTime.Six)
                {
                    int tempHolder = 10;
                    tempHolder = tempHolder - ((int)currentHour);
                    tempPassage = tempPassage - tempHolder;
                    currentHour = CurrentTime.Noon;
                    tempNight.SetActive(false);
                    tempDay.SetActive(true);
                }
                else if (currentHour >= CurrentTime.One)
                {
                    tempDay.SetActive(false);
                    tempNight.SetActive(true);
                }
                currentHour += tempPassage;
                break;
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
            case CurrentTime.ResetHour: //this is specifically if we want to have some sort of animation to indicate a clock reset
                currentHour = CurrentTime.Noon;
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

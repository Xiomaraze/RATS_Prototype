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
    public bool day;
    public bool night;
    enum CurrentTime {EightAM, NineAM, TenAM, ElevenAM, Noon, OnePM, TwoPM, ThreePM, FourPM, FivePM, SixPM, SevenPM, EightPM, NinePM, TenPM, ElevenPM };
    // Start is called before the first frame update
    void Start()
    {
        hour = CurrentTime.EightAM;
        clockText = playerHUD.GetComponent<TextMeshProUGUI>();
    }

    void Display ()
    {
        switch (hour)
        {
            case CurrentTime.EightAM:
                clockText.text = hour.ToString();
                break;
        }    
    }

    // Update is called once per frame
    void Update()
    {
        Display();
    }
}

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static DaySlot;

public class NPCDialogueTester : MonoBehaviour
{
    public GameObject hourManager;
    GameTime hourScript;
    public Canvas canvas;
    public TextMeshProUGUI npcTalkBox;
    DialogueSystem npcDialogue;
    
    enum timeSlot {EarlyDay, LateDay, EarlyNight, LateNight}
    // Start is called before the first frame update
    void Start()
    {
        hourScript = hourManager.GetComponent<GameTime>();
        npcDialogue = gameObject.GetComponent<DialogueSystem>();
    }
    public void Talk()
    {
        //if (hourScript.WhatTime() == 0)
        //{
        //    npcDialogue.GetLine(DaySlot.hour.EarlyDay);
        //}
        //else if (hourScript.WhatTime() == 1)
        //{
        //    npcDialogue.GetLine(DaySlot.hour.LateDay);
        //}
        //else if (hourScript.WhatTime() == 2)
        //{
        //    npcDialogue.GetLine(DaySlot.hour.EarlyNight);
        //}
        //else
        //{
        //    npcDialogue.GetLine(DaySlot.hour.LateNight);
        //}
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

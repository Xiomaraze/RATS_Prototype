using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using JetBrains.Annotations;

[System.Serializable]
public class DialogueArray : MonoBehaviour
{
    public List<string> lines = new List<string>();
    public List<DaySlot> time = new List<DaySlot>();

    private void Start()
    {
        for (int i = 0; i < 4; i++)
        {
            lines.Add("");
            time.Add(time[i]);
        }
    }
}

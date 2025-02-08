using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UIElements;

[SerializableAttribute]
public class DialogueLineTimeArray : MonoBehaviour //ScriptableObject 
{
    public List<string> DayEarlyLines;
    public List<string> DayLateLines;
    public List<string> NightEarlyLines;
    public List<string> NightLateLines;
}
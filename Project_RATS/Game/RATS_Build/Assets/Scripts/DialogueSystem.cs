using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//public class DialogueSystem : MonoBehaviour
//{
//    //List<string> dialogueLines;
//    //public GameObject NPC;
//    //NPCDialogueTester npcLines;
//    //void Start()
//    //{
//    //    npcLines = NPC.GetComponent<NPCDialogueTester>();
//    //    if (npcLines.lines == null) //if the NPC has no lines saved to the system yet, add empty lines to each time "slot" to ensure the system is ready to track their lines
//    //    {
//    //        dialogueLines = new List<string>();
//    //        for (int i = 0; i < 4; i++)
//    //        {
//    //            dialogueLines.Add("");
//    //        }
//    //    }
//    //    else
//    //    {
//    //        dialogueLines = npcLines.lines;
//    //    }
//    //}

//    //public void AddLine(int hour, string line)
//    //{
//    //    //if 
//    //}
//}
public class DialogueSystem : MonoBehaviour
{
    DialogueArray NPCLines;
    GameObject NPC;
    private void Start()
    {
        NPC = gameObject;
        NPCLines = NPC.GetComponent<DialogueArray>();
    }

    public void NewLine(string text, DaySlot.hour slot) //this completely replaces the line in the timeslot given with the text var
    {
        if (NPCLines == null)
        {
            NPCLines = new DialogueArray();
        }
        else
        {
            if (slot == DaySlot.hour.EarlyDay)
            {
                NPCLines.lines[0] = text;
            }
            else if (slot == DaySlot.hour.LateDay)
            {
                NPCLines.lines[1] = text;
            }
            else if (slot == DaySlot.hour.EarlyNight)
            {
                NPCLines.lines[2] = text;
            }
            else if (slot == DaySlot.hour.LateNight)
            {
                NPCLines.lines[3] = text;
            }
            else
            {
                Debug.LogError("Hour Given not found");
            }
        }
    }

    public string GetLine(DaySlot.hour slot) //this will feed back the saved line in that time slot
    {
        if (NPCLines == null)
        {
            Debug.LogError("No associated dialogue lines found. Please ensure the selected object has a filled dialogue set before running GetLine. To add a dialogue line, use NewLine(text, hour).");
        }
        if (slot == DaySlot.hour.EarlyDay)
        {
            return NPCLines.lines[0];
        }
        else if (slot == DaySlot.hour.LateDay)
        {
            return NPCLines.lines[1];
        }
        else if (slot == DaySlot.hour.EarlyNight)
        {
            return NPCLines.lines[2];
        }
        else if (slot == DaySlot.hour.LateNight)
        {
            return NPCLines.lines[3];
        }
        return "Error Line missing";
    }

    public void AddLine(DaySlot.hour slot, string text) //this is specifically to add on to the already present lines
    {
        if (slot == DaySlot.hour.EarlyDay)
        {
            NPCLines.lines[0] = NPCLines.lines[0] + " " + text;
        }
        else if (slot == DaySlot.hour.LateDay)
        {
            NPCLines.lines[0] = NPCLines.lines[1] + " " + text;
        }
        else if (slot == DaySlot.hour.EarlyNight)
        {
            NPCLines.lines[0] = NPCLines.lines[2] + " " + text;
        }
        else if (slot == DaySlot.hour.LateNight)
        {
            NPCLines.lines[0] = NPCLines.lines[3] + " " + text;
        }
    }

}

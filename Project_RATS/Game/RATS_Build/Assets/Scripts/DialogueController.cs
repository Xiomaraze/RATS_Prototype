using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueController : MonoBehaviour
{
    public TextMeshProUGUI textComponent; //text in box referenced in the inspector
    public string[] lines; //these are the actual lines of dialogue displayed on-screen (assign through inspector)
    public float textSpeed; //intervals in seconds between each character displayed

    private int index; //what line of dialogue is currently displayed
    private GameObject dialogueBox; //references the UI to enable and disable it

    void Start()
    {
        dialogueBox = GameObject.Find("DialogueBox"); //gets reference to UI by name
        dialogueBox.SetActive(false); //turn off dialogue box to start
        textComponent.text = string.Empty; //start text empty
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && PlayerController.currentState != PlayerController.States.moving) //text only runs if the player is NOT MOVING!
        {
            if(textComponent.text == lines[index])
            {
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                textComponent.text = lines[index];
            }
        }
    }

    public void StartDialogue() //this gets called through the player controller, after moving to a NPC
    {
        //resets the text
        index = 0;
        textComponent.text = string.Empty;

        //turns on UI
        dialogueBox.SetActive(true);

        //sets player-state to 'talking' so they can't move during conversation
        PlayerController.currentState = PlayerController.States.talking;
        
        //types the first line
        StartCoroutine(TypeLine()); 
    }

    IEnumerator TypeLine() //types out each character
    {
        foreach(char c in lines[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    void NextLine() //moves to next line or ends convo if no more lines are available
    {
        if(index<lines.Length - 1)
        {
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            PlayerController.currentState = PlayerController.States.nothing;
            dialogueBox.SetActive(false);
        }
    }
}

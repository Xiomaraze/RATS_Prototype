using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueController : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public string[] lines;
    public float textSpeed;

    private int index;
    private GameObject dialogueBox;

    //[SerializeField] string speakerName;
    //public List<string> TextBoxes;

    void Start()
    {
        dialogueBox = GameObject.Find("DialogueBox");
        dialogueBox.SetActive(false);
        textComponent.text = string.Empty;
        //StartDialogue();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && PlayerController.currentState != PlayerController.States.moving)
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

    public void StartDialogue()
    {
        index = 0;
        PlayerController.currentState = PlayerController.States.talking;
        dialogueBox.SetActive(true);
        StartCoroutine(TypeLine()); 
    }

    IEnumerator TypeLine()
    {
        foreach(char c in lines[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    void NextLine()
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

using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private bool moving;
    public enum States { moving, talking, nothing };
    public static States currentState;

    
    [SerializeField]
    private float moveSpeed;
    
    private Vector3 clickDestination;
    private Vector3 toDestination;

    InteractableItem currentAction;
    DialogueController currentDialogue;

    private void Start()
    {
        clickDestination = transform.position;    
    }

    void Update()
    {
        Debug.Log(currentState);
        toDestination = clickDestination - transform.position;

        if(currentState == States.moving)
        {
            transform.Translate((toDestination).normalized * Time.deltaTime * moveSpeed);
            if(toDestination.magnitude < .2f)
            {
                if(currentAction != null)
                {
                    currentAction.SpecialAction();
                }
                if(currentDialogue != null)
                {
                    currentDialogue.StartDialogue();
                    currentState = States.talking;
                }
                else currentState = States.nothing;
            }
        }

    }

    public void MoveTo(Vector3 destinationPos)
    {
        clickDestination = destinationPos;
        currentState = States.moving;
        currentAction = null;
        currentDialogue = null;
    }
    
    public void MoveToAndAct(Vector3 destinationPos, GameObject clickedObject)
    {
        MoveTo(destinationPos);
        if (clickedObject.GetComponent<InteractableItem>() != null)
        {
            currentAction = clickedObject.GetComponent<InteractableItem>();
        }
        else if (clickedObject.GetComponent<DialogueController>() != null)
        {
            currentDialogue = clickedObject.GetComponent<DialogueController>();
        }
    }
}

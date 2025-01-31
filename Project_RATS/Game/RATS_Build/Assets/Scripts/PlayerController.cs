using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private bool moving;
    
    [SerializeField]
    private float moveSpeed;
    
    private Vector3 clickDestination;
    private Vector3 toDestination;

    InteractableItem currentAction;

    void Update()
    {
        //if(Input.GetMouseButtonDown(0))
        //{
        //    clickDestination = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.nearClipPlane));
        //    toDestination.z = 0;
        //    moving = true;
        //}

        toDestination = clickDestination - transform.position;

        if(moving)
        {
            transform.Translate((toDestination).normalized * Time.deltaTime * moveSpeed);
            if(toDestination.magnitude < .2f)
            {
                if(currentAction != null)
                {
                    currentAction.SpecialAction();
                }
                moving = false;
            }
        }

    }

    public void MoveTo(Vector3 destinationPos)
    {
        if (!moving)
        {
            clickDestination = destinationPos;
            moving = true;
        }
        currentAction = null;
    }

    public void MoveToAndAct(Vector3 destinationPos, GameObject clickedObject)
    {
        MoveTo(destinationPos);
        currentAction = clickedObject.GetComponent<InteractableItem>();
    }
}

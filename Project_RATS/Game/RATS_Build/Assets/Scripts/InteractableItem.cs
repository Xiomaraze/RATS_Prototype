using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableItem : MonoBehaviour
{
    private Rigidbody2D itemRB;
    public void SpecialAction()
    {
        itemRB = GetComponent<Rigidbody2D>();
        itemRB.AddForce(Vector2.left * 100);
    }
}

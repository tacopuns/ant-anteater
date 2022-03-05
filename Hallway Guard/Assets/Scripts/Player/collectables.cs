using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class collectable : MonoBehaviour
{
    public GameObject crums;

    public void OnTriggerEnter2D(Collider2D other)
    {
    
        {
        MovementTest controller = other.GetComponent<MovementTest>();

        if (controller != null)
            {
            controller.ChangeHunger(25);
            Destroy(gameObject);
            
            }
        }
    }

}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class collectables : MonoBehaviour
{
    public GameObject crumbs;

   void OnCollisionEnter(Collision other) 
   {
     if(other.gameObject.tag == "Player")
     {
        Destroy(gameObject);
     }
    }
    
}
 using System.Collections;
 using System.Collections.Generic;
 using UnityEngine;
 using UnityEngine.AI;

 public class Patrol : MonoBehaviour
 {
     public float speed;
     public Transform[] moveSpots;
     private int randomSpot;
     private float waitTime;
     public float startWaitTime;
     
     void Start()
     {
      
      waitTime = startWaitTime;
      randomSpot = Random.Range(0, moveSpots.Length);
      
     }
 
     void Update()
     {
         transform.position = Vector3.MoveTowards(transform.position, moveSpots[randomSpot].position, speed*Time.deltaTime);
         
         if(Vector3.Distance(transform.position, moveSpots[randomSpot].position)< 0.2f)
         {
         if (waitTime <= 0)
         {
         randomSpot = Random.Range(0, moveSpots.Length);
         waitTime = startWaitTime;
         }
         else
         {
          waitTime -= Time.deltaTime;
         }

         }
     }

 }
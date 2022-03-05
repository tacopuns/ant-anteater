 using System.Collections;
 using System.Collections.Generic;
 using UnityEngine;
 using UnityEngine.AI;

 public class chase : MonoBehaviour
 {
     public float speed;
     public Transform[] moveSpots;
     private int randomSpot;
     private float waitTime;
     public float startWaitTime;
     public Transform player;
     public float maxRange;
     protected NavMeshAgent enemyMesh;
     
     void Start()
     {
      player = GameObject.Find("Ant").transform;
      waitTime = startWaitTime;
      randomSpot = Random.Range(0, moveSpots.Length);
      enemyMesh = GetComponent<NavMeshAgent>();
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
          {  
            float currentDis = Vector3.Distance(transform.position,player.position);
            if (currentDis < maxRange)
             {
              if (isfront() && isLineOfSight())
               {
                enemyMesh.SetDestination(player.position);
               }
             }
         

          }

     }

     bool isfront()
     {
      
      Vector3 directionOfPlayer = transform.position - player.position;
      float angle = Vector3.Angle(transform.forward, directionOfPlayer);

      if (Mathf.Abs(angle) > 90 && Mathf.Abs(angle) < 270)
       
       {
          return true;
       }

       return false;

     }
     
     bool isLineOfSight()
     {

      RaycastHit _hit;
      Vector3 directionOfPlayer = player.position - transform.position;

      if(Physics.Raycast(transform.position, directionOfPlayer, out _hit, 500f))
      {
          if(_hit.transform.name == "Ant")
          
          {
         return true;
          }

      }

       return false;
     
     }

 }
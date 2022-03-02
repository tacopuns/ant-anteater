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
     public Rigidbody rb;
     public Transform target;

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
     
    void FollowPlayer()
     {
         Vector3 pos = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
         rb.MovePosition(pos);
         transform.LookAt(target);
     }
     void OnTriggerStay(Collider player){
               if(player.tag == "Player"){
                 FollowPlayer();
             }
         }
	private void OnTriggerEnter2D(Collider2D collision)
     {
         if (collision.transform.name == "Player")
         {
             collision.GetComponent<MovementTest>().Damage();
         }
     }
 }
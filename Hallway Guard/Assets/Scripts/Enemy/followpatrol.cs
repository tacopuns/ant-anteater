using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class followpatrol : MonoBehaviour
{   public float speed;
    public float range;
    public Transform player;
    public Transform Enemy;
    public NavMeshAgent enemyMesh;
    public Transform[] moveSpots;
    private int randomSpot;
    private float waitTime;
    public float startWaitTime;
    
    // Start is called before the first frame update
    void Start()
    {
      waitTime = startWaitTime;
      randomSpot = Random.Range(0, moveSpots.Length);
      player = GameObject.FindWithTag ("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {

      if (Vector3.Distance(Enemy.position, player.position) <= range)
      {
       enemyMesh.SetDestination(player.position);
      } 
         if (Vector3.Distance(Enemy.position, player.position) > range)
         {
           patrol();
         }  
    }

     public void patrol()
     {
      transform.position = Vector3.MoveTowards(transform.position, moveSpots[randomSpot].position, speed*Time.deltaTime);
         
         if(Vector3.Distance(transform.position, moveSpots[randomSpot].position)< 0.1f)
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
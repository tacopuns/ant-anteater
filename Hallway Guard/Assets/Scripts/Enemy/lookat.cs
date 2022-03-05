using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

  public class lookat : MonoBehaviour
{  

    public Transform player;
    public NavMeshAgent enemyMesh;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
     {
      enemyMesh.SetDestination(player.position);
     }
    
    }   
}

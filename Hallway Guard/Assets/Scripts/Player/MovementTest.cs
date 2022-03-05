using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MovementTest : MonoBehaviour
{

 public bool gameOver = false;

 public GameObject WinPanel;

 public GameObject LosePanel;

 public AudioSource audioSource;

 public AudioClip collectibleSound;

 public AudioClip winClip;

 public AudioClip loseClip;

 public AudioClip hitSound;

 public GameObject points;

 public Text ScoreText;
 
 public int currentHealth = 3;
 
 public Text HealthText;
 
 public CharacterController controller;

 public float speed = 5f;

 public float gravity = -9.81f;

 Vector3 velocity;

 public int Score = 100;

 public Transform groundCheck;

 public float groundDistance = 0.4f;

 public LayerMask groundMask;

 bool isGrounded;

 Animator animator;

 public bool isSprinting = false;
 
 public float sprintSpeed = 15.0f;

    void Start()
    {
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        HealthText.text = "Lives:" + currentHealth.ToString();
    }

    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        velocity.y += gravity + Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);

       if (currentHealth < 1)
        {
           audioSource.PlayOneShot (loseClip,1);
           Destroy(gameObject);
           LosePanel.SetActive(true);
           gameOver = true;
           
		}
    }

    void FixedUpdate()
    {
         if (Input.GetKey(KeyCode.LeftShift))
        {
            isSprinting = true;
        }
        else
        {
            isSprinting = false;
        }

        if (isSprinting == true)
        {
            speed = speed + sprintSpeed;
        }
    }
    public void ChangeHunger (int scoreamount)
      { 
       Score = Score + scoreamount;
       ScoreText.text = "Hunger: " + Score.ToString();
      }   
    

    void Damage()
    {
     currentHealth -= 1;
     audioSource.PlayOneShot(hitSound, 1);
    }

    void OnCollisionEnter(Collision col) 
    {
     if (col.gameObject.name =="Enemy") 
     {
         Debug.Log("<color=red>Error: </color>AssetBundle not found");
        //Damage();
     }
    }
}

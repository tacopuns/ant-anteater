using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MovementTest : MonoBehaviour
{
public int cake;

 public bool gameOver = false;

 public AudioSource audioSource;

 public AudioClip collectibleSound;

 public int damage = 5;

 public AudioClip winClip;

 public AudioClip loseClip;

 public AudioClip hitSound;

 public GameObject points;

 public GameObject pauseMenuUI;

 public Text ScoreText;
 
 public int currentHealth = 3;
 
 public Text HealthText;
 
 public CharacterController controller;

 public float speed = 6f;

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
 
 public float damageDelay = 60f;

 public float damageTimer ;


    void Start()
    {
        ScoreText.text = "Hunger: " + Score.ToString();
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        HealthText.text = "Lives: " + currentHealth.ToString();
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
<<<<<<< Updated upstream
           
           LosePanel.SetActive(true);
=======
           Destroy(gameObject);
           SceneManager.LoadScene("Loss");
>>>>>>> Stashed changes
           //SceneManager.LoadScene("Loss");
           gameOver = true;
           
		}
        if (Score < 0)
        {
           audioSource.PlayOneShot (loseClip,1);
<<<<<<< Updated upstream
           
           LosePanel.SetActive(true);
=======
           Destroy(gameObject);
           SceneManager.LoadScene("Loss");
>>>>>>> Stashed changes
           //SceneManager.LoadScene("Loss");
            gameOver = true;
        }
        {
            HealthText.text = "Lives: " + currentHealth.ToString();
            ScoreText.text = "Hunger: " + Score.ToString();
        }
        if (Score <= 200)
      {
          if (damageTimer < damageDelay)
        {
         damageTimer += Time.deltaTime;
        }
         else if( damageTimer > damageDelay )
         {
         Score -= damage;
         damageTimer = 0f;
         }

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
        if (Input.GetKey(KeyCode.P))
        {
            pauseMenuUI.SetActive(true);
        }
    }
    public void ChangeHunger (int scoreamount)
      { 
       Score = Score + scoreamount;
       ScoreText.text = "Hunger: " + Score.ToString();
       audioSource.PlayOneShot (collectibleSound,1);
      }   
    

    public void Damage()
    {
     currentHealth -= 1;
     audioSource.PlayOneShot(hitSound, 1);

    }

    public void OnCollisionEnter(Collision col) 
    {
     if (col.gameObject.name =="Enemy") 
     {
        Damage();
     }
     if (col.gameObject.name =="Cake")
     {
         Cake();
     }
     if (col.gameObject.tag == "Crumbs")
     {
         {
         ChangeHunger(25);   
         }
     }
    }
    public void Cake()
    {
        //SceneManager.LoadScene("Win");
        audioSource.PlayOneShot (winClip,1);
<<<<<<< Updated upstream
        
        WinPanel.SetActive(true);
=======
        Destroy(gameObject);
        SceneManager.LoadScene("Win");
>>>>>>> Stashed changes
        gameOver = true;
    }
    
}

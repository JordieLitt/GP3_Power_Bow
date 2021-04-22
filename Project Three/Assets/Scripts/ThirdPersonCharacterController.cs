using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ThirdPersonCharacterController : MonoBehaviour
{
    //variables
    public bool isOnGround = true;
    private bool inRange = false;
    private bool inRange2 = false;
    private bool onTop1 = false;
    private bool onTop2 = false;
    private bool jump;
    public bool isInvincible;
    public float invincibleTimer = 3;
    public float jumpForce;
    public float speed = 12f;
    public float groundCheckDistance;
    public LayerMask groundMask;
    public float distanceAhead;
    public float distanceAhead2;
    public int lives;
    private Vector3 hor;
    private Vector3 ver;
    
    //References
    public GameObject platforms;
    public GameObject gate;
    public GameObject b;
    public GameObject targetLocation;
    public GameObject player;
    public Image HealthOne;
    public Image HealthTwo;
    public Image HealthThree;
    public Image HealthFour;
    Rigidbody rigidbody3D;
    private Animator anim;
    private Camera playerCamera;
    public Shoot shootSc;
    AudioSource astraAudioSource;
    public AudioClip astraDamage;
    public AudioClip astraFall;
    public AudioClip astraJump;
  
    void Start()
    {
        lives = 4;

        rigidbody3D = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        astraAudioSource= GetComponent<AudioSource>();
        playerCamera = Camera.main;

        b = GameObject.FindGameObjectWithTag("bow");

        shootSc = b.GetComponent<Shoot>();
    }

    void Update()
    {
        RaycastHit hit2;
        Vector3 forward2 = transform.TransformDirection(Vector3.up * 0.75f) * distanceAhead2;
        Debug.DrawRay(transform.position, forward2, Color.blue);

        if(Physics.Raycast(transform.position,(forward2), out hit2))
        {
           if(hit2.collider.tag == "Lever")
            {
                inRange2 = true;
            }

            else
            {
                inRange2 = false;
            }
        }   

        if(isInvincible)
        {
            invincibleTimer -= Time.deltaTime;
            anim.SetBool("isDamaged", true);
            if(invincibleTimer < 0)
            {
                isInvincible = false;
                anim.SetBool("isDamaged", false);
                invincibleTimer = 3;
            }
        }

        if(Input.GetKeyDown(KeyCode.E))
        {
            RaycastHit hit;
            Vector3 forward = transform.TransformDirection(Vector3.up * 0.75f) * distanceAhead;
            Debug.DrawRay(transform.position, forward, Color.green);

            if(Physics.Raycast(transform.position,(forward), out hit))
            {
                if(hit.collider.tag == "Lever")
                {
                    platforms.SetActive(false);
                    gate.transform.position  += new Vector3 (0f, 7.45f, 0f);
                }
            }
        }

        AttackAni();

        isOnGround = Physics.CheckSphere(transform.position, groundCheckDistance,groundMask);
        if(Input.GetButtonDown("Jump"))
        {
            if(isOnGround)
            {
            jump = true;
            PlaySound(astraJump);
            anim.SetTrigger("jump");
            }
        }
        else if(Input.GetButtonUp("Jump"))
        {
            jump = false;
            anim.SetTrigger("land");
        }

        hor = Input.GetAxis("Horizontal") * playerCamera.transform.right;
        ver = Input.GetAxis("Vertical") * playerCamera.transform.forward;
        Vector3 playerMovement = (hor + ver) * speed;
        print($"This is the forward vector:{playerCamera.transform.forward}");
        print($"This is the right vector:{playerCamera.transform.right}");

        if(playerMovement != Vector3.zero && !Input.GetKey(KeyCode.Space))
        {
            //run
            if(isOnGround)
            {
            anim.SetFloat("Speed", 0.5f, 0.1f, Time.deltaTime);
            
            }
        } 
        else if(playerMovement == Vector3.zero)
        {
            //Idle
            if(isOnGround)
            {
            anim.SetFloat("Speed", 0, 0.1f, Time.deltaTime);
            }
        }
    }

    void FixedUpdate()
    {
       if(jump && isOnGround)
       {
           rigidbody3D.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
       }
       
       Vector3 playerMovement = (hor + ver) * speed;
       playerMovement.y = 0;
       rigidbody3D.velocity = new Vector3(playerMovement.x, rigidbody3D.velocity.y, playerMovement.z);
    }
    

    
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "PPlate1")
        {
            onTop1 = true;
        }

        if(collision.gameObject.tag == "PPlate2")
        {
            onTop2 = true;
        }
    }

    void OnTriggerEnter(Collider col)
    {

        if(col.gameObject.name =="arrowPickup")
        {
            Destroy(col.gameObject);
        }

        if(col.gameObject. CompareTag("DamageZone"))
        {
            lives -=1;
            PlaySound(astraFall);
            
         
            if (lives == 3)
            {
                Destroy(HealthFour.gameObject);
                player.transform.position = targetLocation.transform.position;
            }
            if (lives == 2)
            {
                Destroy(HealthThree.gameObject);
                player.transform.position = targetLocation.transform.position;
            }
            if (lives == 1)
            {
                Destroy(HealthTwo.gameObject);
                player.transform.position = targetLocation.transform.position;
            }
            if (lives == 0)
            {
                Destroy(HealthOne.gameObject);
                PlayerPrefs.SetInt("LastScene", SceneManager.GetActiveScene().buildIndex);
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                SceneManager.LoadScene("LossMenu");
            }
            
        }
        if(col.gameObject. CompareTag("enemy"))
        {
            if(!isInvincible)
            {
            lives -=1;
            PlaySound(astraDamage);
            isInvincible = true;
         
            if (lives == 3)
            {
                Destroy(HealthFour.gameObject);
                
            }
            if (lives == 2)
            {
                Destroy(HealthThree.gameObject);
                
            }
            if (lives == 1)
            {
                Destroy(HealthTwo.gameObject);
                
            }
            if (lives == 0)
            {
                Destroy(HealthOne.gameObject);
                PlayerPrefs.SetInt("LastScene", SceneManager.GetActiveScene().buildIndex);
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                SceneManager.LoadScene("LossMenu");
            }
            }
        }
    }

    private void AttackAni()
    {

    bool isDrawing = Input.GetMouseButton(0) || Input.GetMouseButton(1);

    anim.SetBool("isDrawing", isDrawing);
    }

    public void PlaySound(AudioClip clip)
    {
        astraAudioSource.PlayOneShot(clip);
    }

   
}

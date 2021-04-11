using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ThirdPersonCharacterController : MonoBehaviour
{
    public bool isOnGround = true;

    private Animator anim;

    Rigidbody rigidbody3D;
    public float speed = 12f;
    
    public GameObject pressurePlate1;
    public GameObject pressurePlate2;
    public bool onTop1 = false;
    public bool onTop2 = false;

    AudioSource audioSource;
    

    public float distanceAhead;
    public float distanceAhead2;
    public GameObject message;
    public GameObject message2;
    public bool inRange = false;
    public bool inRange2 = false; 
    public GameObject platforms;
    public GameObject gate;

    public GameObject b;
    public Shoot shootSc;
    //Health
    public int lives;
    public Image HealthOne;
    public Image HealthTwo;
    public Image HealthThree;
    public Image HealthFour;

    public Vector3 jumpForce;
    public GameObject targetLocation;
    public GameObject player;
    public float gravity;

    
  
    void Start()
    {
        lives = 4;

        rigidbody3D = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        audioSource= GetComponent<AudioSource>();
        message.SetActive(false);

        b = GameObject.FindGameObjectWithTag("bow");

        shootSc = b.GetComponent<Shoot>();

        
    }

    // Update is called once per frame
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
           
            // if(hit2.collider.tag == "Crystal")
            // {
            //     inRange = true;
            // }

            // else
            // {
            //     inRange = false;
            // }

            
        }   

        // if(inRange == false)
        // {
        //     message.SetActive(false);
        // }

        // if(inRange == true)
        // {
        //     message.SetActive(true);
        // }

        // if(inRange2 == false)
        // {
        //     message2.SetActive(false);
        // }

        // if(inRange2 == true)
        // {
        //     message2.SetActive(true);
        // }

        if(Input.GetKeyDown(KeyCode.E))
        {
            RaycastHit hit;
            Vector3 forward = transform.TransformDirection(Vector3.up * 0.75f) * distanceAhead;
            Debug.DrawRay(transform.position, forward, Color.green);

            if(Physics.Raycast(transform.position,(forward), out hit))
            {
                if(hit.collider.tag == "Crystal")
                {
                    print("Found crystal");
                    CrystalChecker.instance.crystals += 1;
                    //SceneManager.LoadScene("HubInterior");
                }

                else
                {
                    print("Have not found crystal");
                }

                if(hit.collider.tag == "Lever")
                {
                    platforms.SetActive(false);
                    gate.transform.position  += new Vector3 (0f, 7.45f, 0f);
                }
            }
        }

        AttackAni();
    
     if(Input.GetButtonDown("Jump") && isOnGround == true)
        {
            rigidbody3D.AddForce(jumpForce, ForceMode.Impulse);
            isOnGround = false;
            anim.SetTrigger("jump");
        }
        if(isOnGround == true)
        {
            anim.SetTrigger("land");
        }

        float hor = Input.GetAxis("Horizontal");
        float ver = Input.GetAxis("Vertical");
        Vector3 playerMovement = new Vector3(hor, 0f, ver) * speed * Time.deltaTime;
        
        transform.Translate(playerMovement, Space.Self);

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
            anim.SetFloat("Speed", 0, 0.1f, Time.deltaTime);
        }
    }

    void FixedUpdate()
    {
       
    }
    

    
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            isOnGround = true;
        }

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
        if(col.gameObject.tag =="killBox")
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            SceneManager.LoadScene("LossMenu");
            
        }

        if(col.gameObject.name =="arrowPickup")
        {
            Destroy(col.gameObject);
        }

        if(col.gameObject. CompareTag("DamageZone"))
        {
            lives -=1;
            
         
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
            lives -=1;
            
         
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

    private void AttackAni()
    {

    bool isDrawing = Input.GetMouseButton(0) || Input.GetMouseButton(1);

    anim.SetBool("isDrawing", isDrawing);
    }

    public void PlaySound(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
    }

   
}

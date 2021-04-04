﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ThirdPersonCharacterController : MonoBehaviour
{
    public bool isOnGround = true;

    public GameObject player2Prefab;
    public GameObject player;
    private GameObject player2;
    private Animator anim;

    Rigidbody rigidbody3D;
    public float speed = 12f;

    private bool abilityActive = false;

    public GameObject pressurePlate1;
    public GameObject pressurePlate2;
    public bool onTop1 = false;
    public bool onTop2 = false;

    AudioSource audioSource;
    public AudioClip run;

    public float distanceAhead;
    public float distanceAhead2;
    public GameObject message;
    public bool inRange = false;
    public bool pickup = false;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody3D = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        audioSource= GetComponent<AudioSource>();
        message.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit2;
        Vector3 forward2 = transform.TransformDirection(Vector3.up * 0.75f) * distanceAhead2;
        Debug.DrawRay(transform.position, forward2, Color.blue);

        if(Physics.Raycast(transform.position,(forward2), out hit2))
        {
            if(hit2.collider.tag == "Crystal")
            {
                inRange = true;
            }

            else
            {
                inRange = false;
            }
        }   

        if(inRange == false)
        {
            message.SetActive(false);
        }

        if(inRange == true)
        {
            message.SetActive(true);
        }

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
                    SceneManager.LoadScene("WinMenu");
                }

                else
                {
                    print("Have not found crystal");
                }
            }
        }
        
        if(Input.GetKeyDown(KeyCode.Q) && !abilityActive)
        {
            player2 = Instantiate(player2Prefab, transform.position, transform.rotation);
            player2.transform.Rotate(0, 0, 0);
            StartCoroutine(ResetPosition());
        }

            AttackAni();
    
    }

    void FixedUpdate()
    {
        if(Input.GetButtonDown("Jump") && isOnGround == true)
        {
            rigidbody3D.AddForce(new Vector3(0, 5, 0), ForceMode.Impulse);
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
            anim.SetFloat("Speed", 0.5f, 0.1f, Time.deltaTime);
            PlaySound(run);
        } 
        else if(playerMovement == Vector3.zero)
        {
            //Idle
            anim.SetFloat("Speed", 0, 0.1f, Time.deltaTime);
        }
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

        if(col.gameObject.name =="portal1")
        {
            SceneManager.LoadScene("Forest Level");
        }

        if(col.gameObject.tag =="portal2")
        {
            SceneManager.LoadScene("IceBockout");
        }

        if(col.gameObject.tag == "pickup")
        {
            pickup = true;
        }


    }
    
    private IEnumerator ResetPosition()
    {
        abilityActive = true;
        yield return new WaitForSeconds(10);
        player.transform.position = player2.transform.position;
        Destroy(player2.gameObject);
        abilityActive = false;
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

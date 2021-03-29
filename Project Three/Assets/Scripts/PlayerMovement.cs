using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public GameObject player2Prefab;
    public GameObject player;
    private GameObject player2;
    private Animator anim;

    Rigidbody rigidbody3D;
    public float speed = 12f;

    private bool abilityActive = false;

    public bool isOnGround = true;
    AudioSource audioSource;
    public AudioClip run;

    void Start()
    {
        rigidbody3D = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        audioSource= GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis ("Horizontal");
        float z = Input.GetAxis ("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * speed * Time.deltaTime);

        if(move != Vector3.zero && !Input.GetKey(KeyCode.Space))
        {
            //run
            anim.SetFloat("Speed", 0.5f, 0.1f, Time.deltaTime);
            PlaySound(run);

        }
        else if(move != Vector3.zero && Input.GetKey(KeyCode.Space))
        {
            //Jump
        }
        else if(move == Vector3.zero)
        {
            //Idle
            anim.SetFloat("Speed", 0, 0.1f, Time.deltaTime);
        }

        if(Input.GetKeyDown(KeyCode.Q) && !abilityActive)
        {
            player2 = Instantiate(player2Prefab, transform.position, transform.rotation);
            player2.transform.Rotate(0, 0 ,0);
            StartCoroutine(ResetPosition());
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

    void FixedUpdate()
    {
        if(Input.GetButtonDown("Jump"))
        {
            rigidbody3D.AddForce(new Vector3(0, 5, 0), ForceMode.Impulse);
            isOnGround = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "Ground")
        {
            isOnGround = true;
        }
    }

    public void PlaySound(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
    }
}
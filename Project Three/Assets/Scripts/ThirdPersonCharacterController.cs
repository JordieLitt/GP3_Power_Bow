using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    // Start is called before the first frame update
    void Start()
    {
        rigidbody3D = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        audioSource= GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
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
        if(col.gameObject.tag =="Crystal")
        {
           
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            SceneManager.LoadScene("WinMenu");
            
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
    
    // if(Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1))
    // {
    // anim.SetLayerWeight(anim.GetLayerIndex("Attack Layer"), 1);
    // anim.SetTrigger("DrawArrow");
    // }
            
    // if(Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1))
    // {
    //     anim.SetTrigger("LooseArrow");
    
    // yield return new WaitForSeconds(0.9f);
    // anim.SetLayerWeight(anim.GetLayerIndex("Attack Layer"), 1);   
    // }
    }

    public void PlaySound(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
    }
}

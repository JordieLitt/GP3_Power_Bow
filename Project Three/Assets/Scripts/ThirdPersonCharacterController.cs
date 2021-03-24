using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    
    // Start is called before the first frame update
    void Start()
    {
        rigidbody3D = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q) && !abilityActive)
        {
            player2 = Instantiate(player2Prefab, transform.position, transform.rotation);
            player2.transform.Rotate(-90, 0, 0);
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
        } 
        else if(playerMovement == Vector3.zero)
        {
            //Idle
            anim.SetFloat("Speed", 0, 0.1f, Time.deltaTime);
        }
    }

    
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "Ground")
        {
            isOnGround = true;
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
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    Rigidbody myBody;
    private float lifeTimer = 2f;
    private float timer;
    private bool hitSomething = false;
    private Transform PlayerTransform;
    public Transform TeleportGoal;

    //Audio
     AudioSource audioSource;
    public AudioClip astralImpact;

    // Start is called before the first frame update
    void Start()
    {
        myBody = GetComponent<Rigidbody>();
        transform.rotation = Quaternion.LookRotation(myBody.velocity);
        PlayerTransform = GameObject.Find("Player").transform;
        audioSource= GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer >= lifeTimer)
        {
            Destroy(gameObject);
        }

        if(!hitSomething)
        {
            transform.rotation = Quaternion.LookRotation(myBody.velocity);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "Ground")
        {
            hitSomething = true;
            Stick();
            PlayerTransform.position = TeleportGoal.position;
            PlaySound(astralImpact);
            Destroy(gameObject);
        }
    }

    private void Stick()
    {
        myBody.constraints = RigidbodyConstraints.FreezeAll;
    }
    public void PlaySound(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
    }
}

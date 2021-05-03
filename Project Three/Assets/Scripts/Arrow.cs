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
    public AudioSource audioSource;
    public AudioClip teleport;

    // Start is called before the first frame update
    void Start()
    {
        myBody = GetComponent<Rigidbody>();
        transform.rotation = Quaternion.Euler(0, 149, 90);
        PlayerTransform = GameObject.Find("Player").transform;
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
            transform.rotation = Quaternion.Euler(0, 149, 90);
        }
    }

    private void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.tag == "Ground")
        {
            PlaySound(teleport);
            hitSomething = true;
            Stick();
            PlayerTransform.position = TeleportGoal.position;
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "NoPass")
        {
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow2 : MonoBehaviour
{
    Rigidbody myBody;
    private float lifeTimer2 = 5f;
    private float timer2;
    private bool hitSomething = false;
    
    // Start is called before the first frame update
    void Start()
    {
        myBody = GetComponent<Rigidbody>();
        transform.rotation = Quaternion.LookRotation(myBody.velocity);
    }

    // Update is called once per frame
    void Update()
    {
        timer2 += Time.deltaTime;
        if(timer2 >= lifeTimer2)
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
        if(collision.collider.tag != "Arrow")
        {
            hitSomething = true;
            Stick();
        }

        if(collision.collider.tag == "Target1")
        {
            lifeTimer2 = 15f;
        }
    }

    private void Stick()
    {
        myBody.constraints = RigidbodyConstraints.FreezeAll;
    }
}

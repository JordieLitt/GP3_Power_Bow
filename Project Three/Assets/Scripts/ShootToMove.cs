using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootToMove : MonoBehaviour
{
    public GameObject platform;
    public bool isShot = false;

    public Transform startMarker;
    public Transform endMarker;

    public float speed = 1.0F;

    private float startTime;

    private float journeyLength;

    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;

        journeyLength = Vector3.Distance(startMarker.position, endMarker.position);
    }

    // Update is called once per frame
    void Update()
    {
        if(isShot == true)
        {
            
            float distCovered = (Time.time - startTime) * speed;

        
            float fracJourney = distCovered / journeyLength;

            transform.position = Vector3.Lerp(startMarker.position, endMarker.position, Mathf.PingPong (fracJourney, 1));
        }

        if(isShot == false)
        {
            startMarker.transform.position = platform.transform.position;
            platform.transform.position = startMarker.transform.position;
        }
    }

    private void OnTriggerEnter(Collider collider)
    {
        if(collider.tag == "Arrow2")
        {
            if(isShot != true)
            {
                isShot = true;
            }

            else
            {
                isShot = false;
            }
            
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
      if(collision.gameObject.tag == "Player")
      {
        collision.collider.transform.SetParent(transform);
      }
    }

    private void OnCollisionExit(Collision collision)
    {
      if(collision.gameObject.tag == "Player")
      {
        collision.collider.transform.SetParent(null);
      }
    }
}

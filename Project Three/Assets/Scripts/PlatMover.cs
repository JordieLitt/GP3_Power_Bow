using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatMover : MonoBehaviour
{
    public Transform startMarker;
    public Transform endMarker;

    public float speed = 1.0F;

    private float startTime;

    private float journeyLength;

    private GameObject m_plate;

    // Start is called before the first frame update
    void Start()
    {
        // Keep a note of the time the movement started.
          startTime = Time.time;

        // Calculate the journey length.
          journeyLength = Vector3.Distance(startMarker.position, endMarker.position);

          m_plate = GameObject.FindWithTag("PPlate1");
    }

    // Update is called once per frame
    void Update()
    {
        // Distance moved = time * speed.
          float distCovered = (Time.time - startTime) * speed;

        // Fraction of journey completed = current distance divided by total distance.
          float fracJourney = distCovered / journeyLength;

        // Set our position as a fraction of the distance between the markers and pingpong the movement.
          transform.position = Vector3.Lerp(startMarker.position, endMarker.position, Mathf.PingPong (fracJourney, 1));

          if(m_plate.GetComponent<StepToRemove>().isSteppedOn)
          {
            endMarker.position = transform.position;
          }
    }

    // Another approach aside from parenting, is to add the velocity of the platform to the player basically.

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

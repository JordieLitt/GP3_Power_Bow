using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class floatpressure : MonoBehaviour
{
    public GameObject platforms2;
    public bool projection = false;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            projection = true;
            StartCoroutine(projectionEnd());
        }
    }

    private void OnTriggerEnter(Collider collider)
    {
        if(collider.tag == "Player")
        {
            platforms2.transform.position = new Vector3(317, 174, 141);
        }

        if(collider.tag == "Astra2")
        {
            platforms2.transform.position = new Vector3(317, 174, 141);
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        if(collider.tag == "Player" && projection == false)
        {
            platforms2.transform.position = new Vector3(317, 410, 141);
        }

        if(collider.tag == "Astra2")
        {
            platforms2.transform.position = new Vector3(317, 410, 141);
        }
    }

    private IEnumerator projectionEnd()
    {
        yield return new WaitForSeconds(10);
        projection = false;
    }
}

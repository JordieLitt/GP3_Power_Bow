using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pressure : MonoBehaviour
{
    public GameObject platforms;
    public bool projection = false;

    void Start()
    {
        platforms.SetActive(false);
    }

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
            platforms.SetActive(true);
        }

        if(collider.tag == "Astra2")
        {
            platforms.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        if(collider.tag == "Player" && projection == false)
        {
            platforms.SetActive(false);
        }

        if(collider.tag == "Astra2")
        {
            platforms.SetActive(false);
        }
    }

    private IEnumerator projectionEnd()
    {
        yield return new WaitForSeconds(10);
        projection = false;
    }
}

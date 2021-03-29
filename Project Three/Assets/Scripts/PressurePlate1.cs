using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate1 : MonoBehaviour
{
    public bool astraOn = false;
    public bool astra2On = false;
    public bool projection = false;

    public GameObject pPlate1;
    public GameObject platforms;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            projection = true;
            StartCoroutine(projectionEnd());
        }

        if(projection == true && astraOn == true && astra2On)
        {
            platforms.transform.position = new Vector3(272, 176, 271);
        }
    }

    private void OnTriggerEnter(Collider collider)
    {
        if(collider.tag == "Player" && projection == true)
        {
            astraOn = true;
            astra2On = true;
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        if(collider.tag == "Player" && projection == false)
        {
            astraOn = false;
        }

        if(collider.tag == "Astra2")
        {
            astra2On = false;
        }
    }

    private IEnumerator projectionEnd()
    {
        yield return new WaitForSeconds(10);
        projection = false;
    }
}

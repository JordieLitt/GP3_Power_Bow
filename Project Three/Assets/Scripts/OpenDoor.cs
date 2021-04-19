using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    public bool astraOn = false;
    public bool astra2On = false;
    public bool projection = false;
    public bool isOpened = false;

    public GameObject pPlate1;
    public GameObject gate;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            projection = true;
            StartCoroutine(projectionEnd());
        }

        if(projection == true && astraOn == true && astra2On)
        {
            isOpened = true;
            gate.transform.position += new Vector3 (0f, 7.45f, 0f);
        }
    }

    private void OnTriggerEnter(Collider collider)
    {
        if(collider.tag == "Player" && projection == true)
        {
            if (astraOn != true)
            {
                astraOn = true;
            }
            
            if (astraOn == true)
            {
                astra2On = true;
            }
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

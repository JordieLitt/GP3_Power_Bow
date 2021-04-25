using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeAppear : MonoBehaviour
{
    public GameObject cube1, cube2, cube3;

    public Material matNormal, matChanged;

    public bool onTopOf1;
    public bool onTopOf2;

    // Start is called before the first frame update
    void Start()
    {
        cube1.GetComponent<Renderer>().material = matNormal;
        cube2.GetComponent<Renderer>().material = matNormal;
        cube3.GetComponent<Renderer>().material = matNormal;
    }

    // Update is called once per frame
    void Update()
    {
        if(onTopOf2 == false)
        {
            cube1.GetComponent<Renderer>().material = matNormal;
            cube2.GetComponent<Renderer>().material = matNormal;
            cube3.GetComponent<Renderer>().material = matNormal;
        }

        if(onTopOf1 == true)
        {
            cube1.GetComponent<Renderer>().material = matChanged;
            cube2.GetComponent<Renderer>().material = matChanged;
            cube3.GetComponent<Renderer>().material = matChanged;
        }

        if(onTopOf1 == false)
        {
            cube1.GetComponent<Renderer>().material = matNormal;
            cube2.GetComponent<Renderer>().material = matNormal;
            cube3.GetComponent<Renderer>().material = matNormal;
        }

        if(onTopOf2 == true)
        {
            cube1.GetComponent<Renderer>().material = matChanged;
            cube2.GetComponent<Renderer>().material = matChanged;
            cube3.GetComponent<Renderer>().material = matChanged;
        }
    }

    void OnTriggerEnter(Collider collider)
    {
        if(collider.tag == "Player")
        {
            onTopOf1 = true;
        }

        if(collider.tag == "Astra2")
        {
            onTopOf2 = true;
        }
    }

    void OnTriggerExit(Collider collider)
    {
        if(collider.tag == "Player")
        {
            onTopOf1 = false;
        }
    }
}

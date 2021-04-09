using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public Transform targetLocation;
    public GameObject thePlayer;

    void OntriggerEnter(Collider Other)
    {
        thePlayer.transform.position = targetLocation.transform.position;
    }
}

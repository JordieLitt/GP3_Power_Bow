using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewPlayerStart : MonoBehaviour
{
   public GameObject player;
   public float newX;
   public float newY;
   public float newZ;
    void Start()
    {
        if(CrystalChecker.instance.entered == true)
        {
            player.transform.position = new Vector3(newX, newY, newZ);
        }
    }
}

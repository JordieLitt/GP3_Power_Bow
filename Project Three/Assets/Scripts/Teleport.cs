using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public GameObject thePlayer;
  
  

    void OntriggerEnter(Collider col)
    {
        if(col.gameObject.tag =="Player")
        {
            MoveGameObject();
        }

    }

    public void MoveGameObject()
    {
            thePlayer.transform.position = new Vector3(521.8f, 5.8f, 299.905f);
     }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target3 : MonoBehaviour
{
   public bool isOpened = false;

    public GameObject gate;

    public GameObject symbol;

    private void OnTriggerEnter(Collider col)
    {
        
            if(col.tag == "Arrow2")
            {
                if(isOpened == false)
                {
                    isOpened = true;
                    gate.transform.position += new Vector3 (0f, 1.58f, 0f);
                    Destroy(symbol.gameObject);
                }
            }
    }
}

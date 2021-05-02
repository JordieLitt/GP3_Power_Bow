using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickup : MonoBehaviour
{
    public GameObject shootSc;

    void Start()
    {
        shootSc = GameObject.Find("Elven_Long_Bow");
    }

    public void OnDestroy()
    {
        shootSc.BroadcastMessage("ItemPickedUp", true);

    }
}

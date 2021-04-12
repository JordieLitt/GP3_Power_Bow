using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickup : MonoBehaviour
{
    public GameObject shootSc;
    public GameObject tutorialMessage;
    public float delay = 5f;

    void Start()
    {
        shootSc = GameObject.Find("Elven_Long_Bow");
    }

    public void OnDestroy()
    {
        tutorialMessage.SetActive(true);

        shootSc.BroadcastMessage("ItemPickedUp", true);

        Destroy(tutorialMessage, delay);
    }
}

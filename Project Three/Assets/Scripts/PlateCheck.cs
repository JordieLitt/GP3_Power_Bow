using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateCheck : MonoBehaviour
{
    private GameObject m_player;
    public bool triggered;

    // Start is called before the first frame update
    void Start()
    {
        m_player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if(m_player.GetComponent<ThirdPersonCharacterController>().onTop3)
        {
            triggered = true;
        }
    }
}

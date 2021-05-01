using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dancers : MonoBehaviour
{
    public Animator characterAni;
    public bool flossing;
    public bool grooving;

    void Update()
    {
        FlossTime(); 
        GroovTime(); 
    }

    public void FlossTime()
    {
        if(!flossing)
        {
            if(Input.GetKeyDown(KeyCode.Z))
            {
            characterAni.SetBool("isFlossing", true);
            flossing = true;
            }
        }
        else
        {
            if(Input.GetKeyDown(KeyCode.Z))
            {
            characterAni.SetBool("isFlossing", false);
            flossing = false;
            grooving = false;
            }
        }
    }

    public void GroovTime()
    {
        if(!grooving)
        {
            if(Input.GetKeyDown(KeyCode.X))
            {
            characterAni.SetBool("isGrooving", true);
            grooving = true;
            }
        }
        else
        {
            if(Input.GetKeyDown(KeyCode.X))
            {
            characterAni.SetBool("isGrooving", false);
            grooving = false;
            flossing = false;
            }
        }
    }
}

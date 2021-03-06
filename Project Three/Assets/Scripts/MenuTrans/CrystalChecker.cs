using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrystalChecker : MonoBehaviour 
 {
     public static CrystalChecker instance;
     
     public int crystals;
     public bool entered;
     
     void Awake()
     {
         if(instance != null)
             GameObject.Destroy(instance);
         else
             instance = this;
         
         DontDestroyOnLoad(this);

         crystals = 0;
         entered = false;
     }
 }
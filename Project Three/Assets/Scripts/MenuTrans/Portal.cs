using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    public int targetSceneIndex = 0;
    public int expectedCount = 0;

    void Start()
    {}
    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.CompareTag("Player") && (CrystalChecker.instance.crystals >= expectedCount))
        {
            SceneManager.LoadScene(targetSceneIndex);
        }
    }
}

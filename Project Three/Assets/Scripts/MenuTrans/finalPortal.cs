using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class finalPortal : MonoBehaviour
{
    public int targetSceneIndex = 0;
    public int expectedCount = 0;

    void Start()
    {}
    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.CompareTag("Player") && (CrystalChecker.instance.crystals >= expectedCount))
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            SceneManager.LoadScene(targetSceneIndex);
        }
    }
}

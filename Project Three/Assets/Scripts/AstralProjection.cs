using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AstralProjection : MonoBehaviour
{
    private bool abilityActive = false;
    public bool unlockedAstral = false;

    public GameObject player2Prefab;
    public GameObject player;
    private GameObject player2;
    private GameObject g;

    public MaterialChange matChange;

    void Start()
    {
        g = GameObject.FindGameObjectWithTag("materialCh");

        matChange = g.GetComponent<MaterialChange>();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q) && !abilityActive && unlockedAstral == true)
        {
            player2 = Instantiate(player2Prefab, transform.position, transform.rotation);
            player2.transform.Rotate(0, 0, 0);
            StartCoroutine(ResetPosition());
        }

        if(Input.GetKeyDown(KeyCode.R) && abilityActive == true)
        {
            player.transform.position = player2.transform.position;
            Destroy(player2.gameObject);
            abilityActive = false;
            StopCoroutine(ResetPosition());
        }
    }

    private IEnumerator ResetPosition()
    {
        abilityActive = true;
        yield return new WaitForSeconds(10);
        player.transform.position = player2.transform.position;
        Destroy(player2.gameObject);
        abilityActive = false;
    }

    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.name =="astralPickup")
        {
            unlockedAstral = true;
            Destroy(col.gameObject);
            matChange.astralUnlock = true;
        }
    }
}

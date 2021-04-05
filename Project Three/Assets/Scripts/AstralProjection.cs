using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AstralProjection : MonoBehaviour
{
    private bool abilityActive = false;
    public GameObject player2Prefab;
    public GameObject player;
    private GameObject player2;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q) && !abilityActive)
        {
            player2 = Instantiate(player2Prefab, transform.position, transform.rotation);
            player2.transform.Rotate(0, 0, 0);
            StartCoroutine(ResetPosition());
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
}

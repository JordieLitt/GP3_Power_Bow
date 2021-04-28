using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public class Despawner : MonoBehaviour
{
    private List<GameObject> capturedObjects;
    private float radius;
    // Trees
    [SerializeField] private LayerMask targetMask;
    private SphereCollider sphereCollider;

    void Awake()
    {
        sphereCollider = this.GetComponent<SphereCollider>();

        radius = sphereCollider.radius;

        capturedObjects = new List<GameObject>();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F10))
        {
            Despawn();
        }
    }

    void Despawn()
    {
        capturedObjects.Clear();

            // Find all targets within range of radius.
            var hitResults = Physics.SphereCastAll(transform.position, radius, Vector3.forward, 1, targetMask);

            // Go through the array of target information and add them to our gameobject list (The trees)
            // Then set them to inactive to hide them.
            foreach(var item in hitResults)
            {
                capturedObjects.Add(item.collider.gameObject);
                item.collider.gameObject.SetActive(false);
            }
    }


    void OnTriggerEnter(Collider collider)
    {
        if(collider.CompareTag("Player"))
        {
            // Go through the list of objects and set them active. Then clear the list.
            foreach(var item in capturedObjects)
            {
                item.SetActive(true);
            }

            capturedObjects.Clear();
        }

    }

    void OnTriggerExit(Collider collider)
    {
        if(collider.CompareTag("Player"))
        {
            print("Exited the despawner zone.");
            Despawn();
        }

    }

}

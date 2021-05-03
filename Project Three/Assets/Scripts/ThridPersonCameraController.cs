using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThridPersonCameraController : MonoBehaviour
{
    public float RotationSpeed = 1;
    public Transform Target, Player;
    float mouseX, mouseY;

    public float minDistance = 1.0f;
    public float maxDistance = 4.0f;
    public float smooth = 10.0f;
    Vector3 dollyDir;
    public Vector3 dollyDirAdjusted;
    public float distance;

    public float dis_ray;

    public bool isHeld = false;

    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Awake()
    {
        dollyDir = transform.localPosition.normalized;
        distance = transform.localPosition.magnitude;
    }

    void Update()
    {
        Vector3 desiredCameraPos = transform.parent.TransformPoint (dollyDir * maxDistance);
        RaycastHit hit;

        if(Physics.Linecast (transform.parent.position, desiredCameraPos, out hit) || isHeld == true)
        {
            distance = Mathf.Clamp ((hit.distance * dis_ray), minDistance, maxDistance);
        }

        else
        {
            distance = maxDistance;
        }

        transform.localPosition = Vector3.Lerp (transform.localPosition, dollyDir * distance, Time.deltaTime * smooth);

        if(Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1))
        {
            isHeld = true;
        }

        if(Input.GetMouseButtonUp(0) || Input.GetMouseButtonUp(1))
        {
            isHeld = false;
        }

        if(isHeld == true)
        {
            distance = Mathf.Clamp ((hit.distance * dis_ray), minDistance, maxDistance);
        }

        if(isHeld == false)
        {
            distance = maxDistance;
        }
    }

    void FixedUpdate()
    {
        mouseX += Input.GetAxis("Mouse X") * RotationSpeed;
        mouseY -= Input.GetAxis("Mouse Y") * RotationSpeed;
        mouseY = Mathf.Clamp(mouseY, -35, 60);

        transform.LookAt(Target);

        Target.rotation = Quaternion.Euler(mouseY, mouseX, 0);
        Player.rotation = Quaternion.Euler(0, mouseX, 0);
    }
}

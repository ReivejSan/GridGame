using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField]
    Transform target = null;

    [SerializeField]
    float speed = 1f;

    [SerializeField]
    float innerBuffer = .1f;

    [SerializeField]
    float outerBuffer = 1.5f;

    Vector3 offset;

    bool moving;

    private void Start()
    {
        offset = target.position + transform.position;
    }

    private void Update()
    {
        Vector3 cameraTargetPosition = target.position + offset;
        Vector3 heading = cameraTargetPosition - transform.position;

        float distance = heading.magnitude;

        Vector3 direction = heading / distance;

        if (distance > outerBuffer)
        {
            moving = true;
        }

        if(moving)
        {
            if(distance > innerBuffer)
            {
                transform.position += direction * Time.deltaTime * speed * Mathf.Max(distance, 1f);
            }
            else
            {
                transform.position = cameraTargetPosition;
                moving = false;
            }
        }
    }
}

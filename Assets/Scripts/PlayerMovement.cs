using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField]
    float movementSpeed = .25f;

    [SerializeField]
    float rayLenght = 1.4f;

    [SerializeField]
    float rayOffsetX = .5f;

    [SerializeField]
    float rayOffsetY = .5f;

    [SerializeField]
    float rayOffsetZ = .5f;

    Vector3 targetPosition;
    Vector3 startPosition;

    bool moving;

    void Update()
    {
        if(moving)
        {
            if(Vector3.Distance(startPosition, transform.position) > 1f)
            {
                transform.position = targetPosition;
                moving = false;
                return;
            }
            transform.position += (targetPosition - startPosition) * movementSpeed * Time.deltaTime;
            return;
        }


        if(Input.GetKeyDown(KeyCode.W))
        {
            if(CanMove(Vector3.forward))
            {
                targetPosition = transform.position + Vector3.forward;
                startPosition = transform.position;
                moving = true;
            }
            
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            if(CanMove(Vector3.back))
            {
                targetPosition = transform.position + Vector3.back;
                startPosition = transform.position;
                moving = true;
            }
            
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            if(CanMove(Vector3.left))
            {
                targetPosition = transform.position + Vector3.left;
                startPosition = transform.position;
                moving = true;
            }
            
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            if (CanMove(Vector3.right))
            {
                targetPosition = transform.position + Vector3.right;
                startPosition = transform.position;
                moving = true;
            }
            
        }

    }

    bool CanMove(Vector3 direction)
    {
        if(Vector3.Equals(Vector3.forward, direction) || Vector3.Equals(Vector3.back, direction))
        {
            if(Physics.Raycast(transform.position + Vector3.up * rayOffsetY + Vector3.right * rayOffsetX, direction, rayLenght))
            {
                return false;
            }
            if (Physics.Raycast(transform.position + Vector3.up * rayOffsetY - Vector3.right * rayOffsetX, direction, rayLenght))
            {
                return false;
            }
        }
        else if (Vector3.Equals(Vector3.left, direction) || Vector3.Equals(Vector3.right, direction))
        {
            if (Physics.Raycast(transform.position + Vector3.up * rayOffsetY + Vector3.forward * rayOffsetZ, direction, rayLenght))
            {
                return false;
            }
            if (Physics.Raycast(transform.position + Vector3.up * rayOffsetY - Vector3.forward * rayOffsetZ, direction, rayLenght))
            {
                return false;
            }
        }

        return true;
    }
}

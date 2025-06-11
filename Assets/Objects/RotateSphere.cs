using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class RotateSphere : MonoBehaviour
{
    Vector3 prevPosition = Vector3.zero;
    Vector3 posDelta = Vector3.zero;
    Vector3 prevSpeed = Vector3.zero;
    Vector3 avgSpeed = Vector3.zero;

    [SerializeField] float rotationSpeed = 15f;

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.zero;

        if (Input.GetMouseButton(2))
        {
            posDelta = Input.mousePosition - prevPosition;
            transform.Rotate(Vector3.up, Vector3.Dot(posDelta, -Vector3.right), Space.World);
            transform.Rotate(Vector3.right, Vector3.Dot(posDelta, Vector3.up), Space.World);
            prevSpeed = new Vector3(Input.GetAxis("Mouse Y") * rotationSpeed, 0, Input.GetAxis("Mouse X") * rotationSpeed);
        }

        prevPosition = Input.mousePosition;

        
    }

}



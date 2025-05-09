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

    float lerpSpeed = 1.0f;

    bool dragging = false;

    [SerializeField] float rotationSpeed = 15f;
    
    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.zero;
        /*if (Input.GetMouseButton(0) && dragging){
            prevSpeed = new Vector3(-Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"), 0);
            avgSpeed = Vector3.Lerp(avgSpeed, prevSpeed, Time.deltaTime*5);
        } else {
            if (dragging){
                prevSpeed = avgSpeed;
            }
            float i = Time.deltaTime * lerpSpeed;
            prevSpeed = Vector3.Lerp(prevSpeed, Vector3.zero, i);
        }

        transform.Rotate(Vector3.up * prevSpeed.x * rotationSpeed, Space.World);
        transform.Rotate(Vector3.right * prevSpeed.y * rotationSpeed, Space.World);*/

        if(Input.GetMouseButton(2)){
            posDelta = Input.mousePosition - prevPosition;
            transform.Rotate(Vector3.up, Vector3.Dot(posDelta, -Vector3.right), Space.World);
            transform.Rotate(Vector3.right, Vector3.Dot(posDelta, Vector3.up), Space.World); 
            prevSpeed = new Vector3(Input.GetAxis("Mouse Y") * rotationSpeed, 0, Input.GetAxis("Mouse X") * rotationSpeed);
        }

        prevPosition = Input.mousePosition;

        
    }

}



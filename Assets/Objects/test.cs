using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class test : MonoBehaviour
{
    // Start is called before the first frame update

    public Transform orientation;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawLine(orientation.position, orientation.right * 5);
    }
}

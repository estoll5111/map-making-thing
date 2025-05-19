using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatController : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject drawSphere;
    public Material[] materials = new Material[5];
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    
    public void changeMaterial(int index){ 
     drawSphere.GetComponent<MeshRenderer>().material = materials[index];
}
}

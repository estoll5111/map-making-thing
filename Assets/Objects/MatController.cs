using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatController : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject drawSphere;
    public Color[] allColors = new Color[5];

    public Material baseMaterial;
    private Material sphereMat;
    public float scale;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void changeMaterial(int index)
    {
        Debug.Log("attempt change");
        sphereMat = new Material(baseMaterial);
        sphereMat.color = allColors[index];
        drawSphere.GetComponent<Renderer>().material = sphereMat;
    }

    public void changeSize(float newScale)
    {
        Debug.Log("attempt size change");
        drawSphere.transform.localScale = new Vector3(newScale, newScale, 0.005f);

    }
}

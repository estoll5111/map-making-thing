using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEditor.Rendering;
using UnityEngine;

public class MatController : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject drawSphere;
    public GameObject globe;
    public Color[] allColors = new Color[5];

    public Material baseMaterial;
    private Material sphereMat;
    public float scale;
    public drawTest undotest;


    void Start()
    {
        undotest.GetComponent<drawTest>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void changeMaterial(int index)
    {
        sphereMat = new Material(baseMaterial);
        sphereMat.color = allColors[index];
        drawSphere.GetComponent<Renderer>().material = sphereMat;
    }

    public void changeSize(float newScale)
    {
        drawSphere.transform.localScale = new Vector3(newScale, newScale, 0.005f);
    }

    public void resetRotation()
    {
        globe.transform.rotation = new Quaternion(0, 0, 0, 1);
    }

    public void back()
    {
        int y = 0;
        Debug.Log("Attempting to destroy " + undotest.testMult[undotest.testMult.Count - 1].Count + " objects.");
        if (undotest.testMult.Count == 1)
        {
            Debug.Log("There is nothing drawn, canceling undo");
            //does not work need to fix
            return;
        }
        for (int x = undotest.testMult[undotest.testMult.Count - 1].Count - 1; x >= 0; x--)
        {
            Destroy(undotest.testMult[undotest.testMult.Count - 1][x]);
            y++;
        }
        Debug.Log("Destroyed " + y + " objects");
        undotest.testMult.RemoveAt(undotest.testMult.Count - 1);
        undotest.undoLists--;
    }
}

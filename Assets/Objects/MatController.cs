using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
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

    public List<GameObject> undo;
    void Start()
    {

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
        Debug.Log("Attempting to destroy " + undo.Count + " objects.");
        for (int x = undo.Count; x > 0; x--)
        {
            Destroy(undo[x]);
            y++;
        }
        Debug.Log("Destroyed " + y + " objects");
    }
}

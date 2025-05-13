using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class draw : MonoBehaviour
{

    public GameObject drawSphere; 
    public GameObject parent;
    private Vector3 mousePos;
    // Start is called before the first frame update
    void Start()
    {
        mousePos = Input.mousePosition;
        mousePos.z = Camera.main.nearClipPlane;
    }

    // Update is called once per frame
    void Update()
    {
        mousePos = Input.mousePosition;

       /* RaycastHit hit;
        Ray ray = new Ray(Camera.main.ScreenPointToRay(mousePos).origin, Camera.main.ScreenPointToRay(Input.mousePosition).direction);
        if (Physics.Raycast(ray, out hit, Mathf.Infinity)){
            GameObject drawn = Instantiate(drawSphere, hit.point, Quaternion.identity, transform.parent);
            Debug.DrawLine(ray.origin, hit.point, Color.green, 1.0f);
            Debug.Log("hit");
        } */
    }
}

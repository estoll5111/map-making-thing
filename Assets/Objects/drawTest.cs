using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.Rendering;

public class drawTest : MonoBehaviour
{
    // Start is called before the first frame update

    Vector3 mousePos;
    Vector3 worldMousePos;
    public RaycastHit hit;
    public GameObject drawSphere;

    public List<GameObject> undo = new List<GameObject>();


    public KeyCode draw = KeyCode.Mouse0;

    private void Awake()
    {

        mousePos = Input.mousePosition;
        mousePos.z = Camera.main.nearClipPlane;
        Vector3 worldMousePos = Camera.main.ScreenToWorldPoint(mousePos);
        transform.position = worldMousePos;
    }
    void Start()
    {
        Debug.Log("Start called");
        mousePos = Input.mousePosition;
        mousePos.z = Camera.main.nearClipPlane;
        worldMousePos = Camera.main.ScreenToWorldPoint(mousePos);
    }

    // Update is called once per frame
    void Update()
    {
        mousePos = Input.mousePosition;
        if (Input.GetKey(draw))
        {
            undo.Clear();
            Ray ray = new Ray(Camera.main.ScreenPointToRay(mousePos).origin, Camera.main.ScreenPointToRay(Input.mousePosition).direction);
            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                GameObject drawn = Instantiate(drawSphere, hit.point, Quaternion.identity, transform);
                drawn.transform.LookAt(transform.position);
                undo.Add(drawn);
                Debug.DrawLine(ray.origin, hit.point, Color.red, 1.0f);
            }
        }
        while(Input.GetKey(draw))
        mousePos.z = hit.point.z;
        Vector3 worldMousePos = Camera.main.ScreenToWorldPoint(mousePos);
        transform.position = worldMousePos;
    }
    
    
}

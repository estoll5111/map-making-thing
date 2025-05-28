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

    private bool drawing;

    public List<List<GameObject>> testMult = new List<List<GameObject>>(1);

    public int undoLists = 0;


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
        testMult.Add(new List<GameObject>());
    }

    
    // Update is called once per frame
    void Update()
    {
        mousePos = Input.mousePosition;
        if (Input.GetKey(draw))
        {
            Ray ray = new Ray(Camera.main.ScreenPointToRay(mousePos).origin, Camera.main.ScreenPointToRay(Input.mousePosition).direction);
            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                GameObject drawn = Instantiate(drawSphere, hit.point, Quaternion.identity, transform);
                //undo.Add(drawn);
                testMult[undoLists].Add(drawn);
                drawn.transform.LookAt(transform.position);
                Debug.DrawLine(ray.origin, hit.point, Color.red, 1.0f);
            }
        }
        else drawing = false;
        mousePos.z = hit.point.z;
        Vector3 worldMousePos = Camera.main.ScreenToWorldPoint(mousePos);
        transform.position = worldMousePos;
    }
    void OnMouseDown()
    {
        testMult.Add(new List<GameObject>());
        undoLists++;
        Debug.Log(testMult.Count + " lists of lists");

    }
}

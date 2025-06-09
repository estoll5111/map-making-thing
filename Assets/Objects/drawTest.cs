using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
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

    public GameObject plane;


    public KeyCode draw = KeyCode.Mouse0;
    public bool erasing;

    public bool stamping;

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
        if (!erasing && !stamping)
        {
            if (Input.GetKey(draw))
            {
                LayerMask mask = LayerMask.GetMask("Globe");
                Ray ray = new Ray(Camera.main.ScreenPointToRay(mousePos).origin, Camera.main.ScreenPointToRay(Input.mousePosition).direction);
                if (Physics.Raycast(ray, out hit, Mathf.Infinity, mask))
                {
                    GameObject drawn = Instantiate(drawSphere, hit.point, Quaternion.identity, transform);
                    testMult[undoLists].Add(drawn);
                    drawn.transform.LookAt(transform.position);
                    Debug.DrawLine(ray.origin, hit.point, Color.red, 1.0f);
                }
            }
            else drawing = false;
        }
        else if (erasing)
        {
            erase();
        }
        else if (stamping)
        {
            printCity();
            
        }
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

    public void erase()
    {
        LayerMask drawnMask = LayerMask.GetMask("DrawnObject");
        Ray ray = new Ray(Camera.main.ScreenPointToRay(mousePos).origin, Camera.main.ScreenPointToRay(Input.mousePosition).direction);

        if (Physics.Raycast(ray, out hit, Mathf.Infinity, drawnMask) && Input.GetKey(draw))
        {
            Debug.DrawLine(ray.origin, hit.point, Color.green, 1.0f);
            Destroy(hit.collider.gameObject);
            Debug.Log("Deleted object");
        }
    }

    public void printCity()
    {
         LayerMask mask = LayerMask.GetMask("Globe");
         Ray ray = new Ray(Camera.main.ScreenPointToRay(mousePos).origin, Camera.main.ScreenPointToRay(Input.mousePosition).direction);
        if (Physics.Raycast(ray, out hit, Mathf.Infinity, mask) && Input.GetKey(draw))
        {
            GameObject drawn = Instantiate(plane, hit.point, Quaternion.identity, transform);
            testMult[undoLists].Add(drawn);
            drawn.transform.LookAt(transform.position);
            drawn.transform.Translate(new Vector3(0,0,-0.05f));
            stamping = false;
        }
    }

}

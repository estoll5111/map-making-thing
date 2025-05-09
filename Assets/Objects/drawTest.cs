using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Rendering;

public class drawTest : MonoBehaviour
{
    // Start is called before the first frame update

    Vector3 mousePos;
    Vector3 worldMousePos;
    public RaycastHit hit;

    public KeyCode draw = KeyCode.Mouse0;
    private void Awake()
    {
        Mesh testMesh = new Mesh();

        Vector3[] vertices = new Vector3[4];
        Vector2[] uv = new Vector2[4];
        int[] triangles = new int[6];

        vertices[0] = new Vector3(-0.1f, 0.1f);
        vertices[1] = new Vector3(-0.1f, -0.1f);
        vertices[2] = new Vector3(0.1f, -0.1f);
        vertices[3] = new Vector3(0.1f, 0.1f);

        uv[0] = Vector2.zero;
        uv[1] = Vector2.zero;
        uv[2] = Vector2.zero;
        uv[3] = Vector2.zero;

        triangles[0] = 0;
        triangles[1] = 3;
        triangles[2] = 1;

        triangles[3] = 1;
        triangles[4] = 3;
        triangles[5] = 2;

        testMesh.vertices = vertices;
        testMesh.uv = uv;
        testMesh.triangles = triangles;
        testMesh.MarkDynamic();
        GetComponent<MeshFilter>().mesh = testMesh;

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
        if (Input.GetKey(draw)){
            Debug.Log("mousebutton0 down");
                Ray ray = new Ray(Camera.main.ScreenPointToRay(mousePos).origin, Camera.main.ScreenPointToRay(Input.mousePosition).direction);
                if (Physics.Raycast(ray, out hit, Mathf.Infinity)){
                    Debug.DrawLine(ray.origin, hit.point, Color.red, 1.0f);
                   // Debug.Log(hit.point.z);
                } 

        }
        mousePos.z = hit.point.z;
        Vector3 worldMousePos = Camera.main.ScreenToWorldPoint(mousePos);
        transform.position = worldMousePos;
        Debug.Log(hit.point.z);
    }
}

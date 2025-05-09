using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{

    private Vector3 mousePos = Vector3.zero;
    RaycastHit hit = new RaycastHit();
    private void Awake()
    {
        hit = GameObject.Find("Sphere block out").GetComponent<drawTest>().hit;
        
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

    private void Update()
    {
        mousePos = Input.mousePosition;
        mousePos.z = hit.point.z;
        Vector3 worldMousePos = Camera.main.ScreenToWorldPoint(mousePos);
        transform.position = worldMousePos;
        Debug.Log(hit.point.z);
    }
}

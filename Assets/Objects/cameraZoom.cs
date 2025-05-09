using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraZoom : MonoBehaviour
{
    // Start is called before the first frame update

    Vector2 mouseScroll;
    Vector3 cameraStartPos = new Vector3(0,0,-2.3f);

    Vector3 cameraPos;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        cameraPos = transform.position;
        mouseScroll = Input.mouseScrollDelta;
        transform.position = Vector3.Lerp(cameraPos, cameraPos*mouseScroll, 0.1f);
    }
}

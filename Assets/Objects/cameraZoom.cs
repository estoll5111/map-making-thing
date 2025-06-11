using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class cameraZoom : MonoBehaviour
{
  // Start is called before the first frame update
  public float startingFOV = 54.5f;
  public float maxFOV = 80.4f;
  public float minFOV = 1;
  public float FOV;
  void Start()
  {
    FOV = Camera.main.fieldOfView;
    Camera.main.fieldOfView = startingFOV;
    }

  // Update is called once per frame
  void Update()
  {
    if (Input.GetAxis("Mouse ScrollWheel") > 0f && FOV >= minFOV)
    {
      FOV--;
    }
    else if (Input.GetAxis("Mouse ScrollWheel") < 0f && FOV <= maxFOV)
    {
      FOV++;
    }

    Camera.main.fieldOfView = FOV;
    }
}

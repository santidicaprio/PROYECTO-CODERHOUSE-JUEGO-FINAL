using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FpsCamera : MonoBehaviour
{
    public Camera FPSCamera;
    public float horizontalSpeed;
    public float verticalSpeed;

    float h;
    float v;

    void Start()
    {
        
    }

    
    void Update()
    {
        h = horizontalSpeed * Input.GetAxis("Mouse X");
        v = verticalSpeed * Input.GetAxis("Mouse Y");

        transform.Rotate (0, h, 0);
        FPSCamera.transform.Rotate (-v, 0, 0);

        if (Input.GetKey(KeyCode.W))
        {
            Debug.Log("hola");
            transform.Translate(0, 0, 1f);
        }
    }
}

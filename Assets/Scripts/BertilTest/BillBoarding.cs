using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BillBoarding : MonoBehaviour
{
    Camera cam;
    public Transform camTransform;

    Quaternion originalRotation;

    void Start()
    {
        cam = Camera.main;
        originalRotation = transform.rotation;
    }

    void Update()
    {
        camTransform = cam.gameObject.transform;
        transform.rotation = camTransform.rotation * originalRotation;
    }
}

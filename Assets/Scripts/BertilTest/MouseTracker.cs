using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseTracker : MonoBehaviour
{
    Camera cam;
    public GameObject cube;
    Quaternion rot;
    public Vector3 worldPosition;

    void Start()
    {
        rot = this.gameObject.transform.rotation;
        cam = GetComponent<Camera>();
    }

    void Update()
    {
        /*Plane plane = new Plane(Vector3.up, 0);

        float distance;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (plane.Raycast(ray, out distance))
        {
            worldPosition = ray.GetPoint(distance);
        }*/

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitData;

        if (Physics.Raycast(ray, out hitData, 1000))
        {
            worldPosition = hitData.point;
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            PlaceCube();
        }
    }
    void PlaceCube()
    {
        Instantiate(cube, worldPosition, rot);
    }
}

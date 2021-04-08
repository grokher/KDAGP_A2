using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CamRotation : MonoBehaviour
{
    [Range(1, 5)] public float speed = 3.5f;
    [SerializeField, Range(1, 99)] private float maxXAngle = 85f;
    private float x, y;
    public Texture2D c1, c2;

    void Update()
    {
        if (Input.GetMouseButton(1))
        {          
            x += Input.GetAxis("Mouse Y") * speed;
            x = Mathf.Clamp(x, -maxXAngle, maxXAngle);
            y -= Input.GetAxis("Mouse X") * speed;
            transform.rotation = Quaternion.Euler(x, y, 0);
            Cursor.SetCursor(c2, Vector2.zero, CursorMode.ForceSoftware);
        }
        else
        {
            Cursor.SetCursor(c1, Vector2.zero, CursorMode.ForceSoftware);
        }
    }
}
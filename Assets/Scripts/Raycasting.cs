using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Raycasting : MonoBehaviour
{
    Camera playerCamera;
    RaycastHit hit;

    public static Raycasting current;
    public event Action<string> interactionTriggerd;

    private void Awake()
    {
        current = this;
        playerCamera = Camera.main;
    }

    private void Update()
    {
        Ray ray = playerCamera.ScreenPointToRay(Input.mousePosition);

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if(Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                Debug.DrawRay(ray.origin, (playerCamera.transform.rotation * Vector3.forward) * hit.distance, Color.white);

                if (hit.transform.GetComponent<MoveButton>() != null)
                {
                    if (interactionTriggerd != null)
                    {
                        interactionTriggerd(hit.transform.name);
                    }
                }
            }
        }
    }
}

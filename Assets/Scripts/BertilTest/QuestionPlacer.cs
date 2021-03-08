using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionPlacer : MonoBehaviour
{
    bool placeQuest = false;
    public Camera camera;

    void Start()
    {
        
    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            Debug.Log(camera.ScreenToWorldPoint(Input.mousePosition));
        }
    }

    public void EnablePlace()
    {
        placeQuest = true;
    }
}

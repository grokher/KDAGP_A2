using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeArea : MonoBehaviour
{
    public Material[] skyboxes;
    int currentArea = 0;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            NextArea();
        }
        if ((Input.GetKeyDown(KeyCode.LeftAlt)))
        {
            LastArea();
        }
    }

    void GoToArea(int areaNum)
    {
        RenderSettings.skybox = skyboxes[areaNum];
    }

    void NextArea()
    {
        RenderSettings.skybox = skyboxes[currentArea];

        currentArea++;

        if (currentArea >= skyboxes.Length)
        {
            currentArea = 0;
        }
    }

    void LastArea()
    {
        RenderSettings.skybox = skyboxes[currentArea];

        currentArea--;

        if (currentArea < 0)
        {
            currentArea = skyboxes.Length;
        }
    }
}

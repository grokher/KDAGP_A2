using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingMode : MonoBehaviour
{
    Canvas buildingWindow;

    private void Start()
    {
        buildingWindow = this.gameObject.GetComponent<Canvas>();

        SetWindow();
    }

    public void SetWindow()
    {
        buildingWindow.enabled = !buildingWindow.enabled;
    }
}

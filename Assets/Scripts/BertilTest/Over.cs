using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Over : MonoBehaviour
{
    public DetectMouse dm;
    
    private void OnMouseOver()
    {
        dm.mouseOver = true;
    }

    private void OnMouseExit()
    {
        dm.mouseOver = false;
    }
}

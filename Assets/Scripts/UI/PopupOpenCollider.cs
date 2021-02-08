using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupOpenCollider : MonoBehaviour
{
    public DetectMouse detMou;

    private void OnMouseOver()
    {
        detMou.keepOpen = true;
    }

    private void OnMouseExit()
    {
        detMou.keepOpen = false;
    }
}

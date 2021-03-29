using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Over : MonoBehaviour
{
    public PopupOpenCollider ppc;
    
    private void OnMouseExit()
    {
        ppc.keepOpen = false;
    }
}

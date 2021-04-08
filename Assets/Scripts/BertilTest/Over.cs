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
    //RANT TIME
    //So idunno why maar de colliders op de popup refusen om goed mee te werken en negeren soms als de muis van de popup weg is
    //Waarom moet dit dan zo FUCK DO I KNOW but i works so goshdarnit im sticking with it ):<
}

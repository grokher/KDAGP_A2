using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class StartAnimation : MonoBehaviour
{
    public Animator anim;
    
    private void Update()
    {
        anim.SetBool("open", true);
        if (anim.GetBool("open") == true)
        {

        }

    }
}

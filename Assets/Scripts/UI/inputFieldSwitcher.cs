using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class inputFieldSwitcher : MonoBehaviour
{
    [SerializeField]InputField[] fields;
    bool focus;

    void Update()
    {
        SwitchTab();
    }

    void SwitchTab()
    {
        //Tab check voor login om van field te wisselen
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            //Kijkt welk veld active is en geeft aan welke het active is
            if (fields[1].isFocused)
            {
                focus = false;
            }
            else if (fields[0].isFocused)
            {
                focus = true;
            }
            //

            focus = !focus;

            //Switched inputfield
            if (focus)
            {
                fields[0].ActivateInputField();
            }
            else
            {
                fields[1].ActivateInputField();
            }
            //
        }
    }
    
}

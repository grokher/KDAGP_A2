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
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (fields[1].isFocused)
            {
                focus = false;
            }
            else if (fields[0].isFocused)
            {
                focus = true;
            }

            focus = !focus;
            if (focus)
            {
                fields[0].ActivateInputField();
            }
            else
            {
                fields[1].ActivateInputField();
            }
        }
    }
    
}

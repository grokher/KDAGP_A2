using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class inputFieldSwitcher : MonoBehaviour
{
    [SerializeField]InputField[] fields;
    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < fields.Length; i++)
        {
            if (fields[i].isActiveAndEnabled && Input.GetKeyDown(KeyCode.Tab))
            {
                fields[i +1].ActivateInputField();
            }
        }
      
    }
}

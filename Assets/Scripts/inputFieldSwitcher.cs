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
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            for (int i = 0; i < fields.Length; i++)
            {                
                if (fields[i].isActiveAndEnabled)
                {
                    Debug.Log((i).ToString());
                    if ((i + 2) > fields.Length)
                    {
                        Debug.Log("Field is:" + (i + 2).ToString());
                        Debug.Log("Length is:" + fields.Length.ToString());
                        fields[0].ActivateInputField();
                    }
                    if ((i + 2) <= fields.Length)
                    {
                        Debug.Log("This is" + (i + 1).ToString());
                        fields[i + 1].ActivateInputField();
                    }
                    
                    return;
                }
            }
        }    
    }
}

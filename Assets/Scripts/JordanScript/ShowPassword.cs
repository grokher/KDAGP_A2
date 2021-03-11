using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowPassword : MonoBehaviour
{
    public InputField passwordField;

    // Start is called before the first frame update
    public void Password(bool value)
    {
        if (value == true)
        {
            passwordField.contentType = InputField.ContentType.Standard;
            passwordField.Select();
        }
        else
        {
            passwordField.contentType = InputField.ContentType.Password;
            passwordField.Select();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddUser : MonoBehaviour
{
    public InputField username;
    public InputField password;
    public Button createButton;

    public string Url;
    WWWForm form;
    
    public void OnButtonclick()
    {
        createButton.interactable = false;
        StartCoroutine(CreateUser());
    }
    IEnumerator CreateUser()
    {
        form = new WWWForm();

        form.AddField("NewUserName", username.text);
        form.AddField("NewUserPassword", password.text);
        //form.AddField("NewRights", Rights.text);

        WWW w = new WWW(Url,form);

        yield return w;
        if (w.error != null)
        {
            
            Debug.Log("<color=red>" +w.error+ "</color>");//error
        }
        else
        {
            if (w.isDone)
            {
                // als de echo een error woord bevat
                if (w.text.Contains("error"))
                {
                   
                    Debug.Log("<color=red>" +"testest" + "</color>");//error
                }
                else
                {
                    
                    
                    Debug.Log(w.text);
                }
            }
        }

        createButton.interactable = true;
        w.Dispose();
    }
    
   
}

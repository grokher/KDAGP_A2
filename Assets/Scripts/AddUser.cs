using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddUser : MonoBehaviour
{
    public InputField username;
    public InputField password;
    public Dropdown rights;
    private string roleName;
    public Button createButton;

    public Text createMessage;

    public string Url;
    WWWForm form;
    private void Start()
    {
        createMessage.gameObject.SetActive(false);
    }
    public void OnButtonclick()
    {
        createMessage.gameObject.SetActive(true);
        createButton.interactable = false;
        StartCoroutine(CreateUser());
    }
    private void Update()
    {
        if(rights.value == 0)
        {
            roleName = "Student";
            createMessage.text = "<color=green>" + "You created a student account" + "</color>";
        }
        else if(rights.value == 1){
            roleName = "Docent";
            createMessage.text = "<color=green>" + "You created a docent account" + "</color>";
        }
        else if (rights.value == 2)
        {
            roleName = "Beheerder";
            createMessage.text = "<color=green>" + "You created a beheerder account" + "</color>";
        }
        else
        {
            Debug.Log("error no role was given");
        }
    }
    IEnumerator CreateUser()
    {
        form = new WWWForm();

        form.AddField("NewUserName", username.text);
        form.AddField("NewUserPassword", password.text);
        form.AddField("NewRights", roleName);

        WWW w = new WWW(Url,form);

        yield return w;

        if (w.text.Contains("usernameError"))
        {
            Debug.Log("<color=red>" + w.text + "</color>");
        }
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

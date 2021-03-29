using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlockUser : MonoBehaviour
{
    public Button blockButton;

    //public Text blockMessage;

    public string Url;

    WWWForm form;

    /*private void Start()
    {
        blockMessage.gameObject.SetActive(false);
    }*/

    public void blockUser()
    {
        //blockMessage.gameObject.SetActive(true);
        blockButton.interactable = false;
        StartCoroutine(CreateUser(UserSelect.username, UserSelect.blocked));
    }

    IEnumerator CreateUser(string username, string blocked)
    {
        form = new WWWForm();

        username = username.Substring(1, username.Length - 2);
        blocked = blocked.Substring(1, blocked.Length - 2);

        form.AddField("username", username);
        form.AddField("blocked", blocked);

        WWW w = new WWW(Url, form);

        yield return w;

        //Debug.Log(w.text);

        if (w.error != null)
        {

            Debug.Log("<color=red>" + w.error + "</color>");//error
        }
        else
        {
            if (w.isDone)
            {
                // als de echo een error woord bevat
                if (w.text.Contains("Error"))
                {

                    Debug.Log("<color=red>" + w.text + "</color>");//error
                }
                else
                {
                    Debug.Log("<color=green>" + w.text + "</color>");
                }
            }
        }

        w.Dispose();

        blockButton.interactable = true;
    }
}

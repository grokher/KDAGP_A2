using System;
using System.Collections;
using System.Threading.Tasks;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AddToets : MonoBehaviour
{
    public InputField toetsname;
    public Text createMessage;
    public Button createButton;
    public string Url;
    WWWForm form;

    public void OnButtonclick()
    {
        createButton.interactable = false;
        StartCoroutine(CreateToets());
    }

    IEnumerator CreateToets()
    {
        form = new WWWForm();

        form.AddField("NewToets", toetsname.text);

        WWW w = new WWW(Url, form);

        yield return w;

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
                    createMessage.gameObject.SetActive(true);
                    createMessage.text = ("<color=green>" + w.text + "</color>");
                    RemoveCreateMessage();
                }
            }
        }

        createButton.interactable = true;

        w.Dispose();
    }

    private async void RemoveCreateMessage()
    {
        await Task.Delay(TimeSpan.FromSeconds(5));
        createMessage.gameObject.SetActive(false);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestionsInsert : MonoBehaviour
{
    public string URL;
    public Text question;
    WWWForm form;


    public void idk()
    {
        StartCoroutine(GetUsersList());
    }


    IEnumerator GetUsersList()
    {
        form = new WWWForm();
        form.AddField("Question", question.text);

        WWW w = new WWW(URL, form);


        yield return w;
        if (w.error != null)
        {
            Debug.Log(w.error);
        }
        if (w.isDone)
        {
            Debug.Log(w.text);
        }
        w.Dispose();
    }
}

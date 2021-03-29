using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class QuestionsInsert : MonoBehaviour
{
    public string URL;
    public InputField question;
    InputField answer;
    [SerializeField] Text correctAnswerText;
    WWWForm form;


    public void idk()
    {
        StartCoroutine(GetUsersList());
    }

    public void CorrectAnswer()
    {
        answer = EventSystem.current.currentSelectedGameObject.gameObject.GetComponentInChildren<InputField>();   
        if (answer.text != "")
        {
            Debug.Log(answer.text);
            correctAnswerText.text = EventSystem.current.currentSelectedGameObject.gameObject.GetComponentInChildren<Text>().text;
        }
        else
        {
            Debug.Log("Error, no answer given.");
        }
    }

    IEnumerator GetUsersList()
    {
        form = new WWWForm();
        form.AddField("Question", question.text);
        form.AddField("CorrectAnswers", correctAnswerText.text);
        //form.AddField("ID", + 1);
        WWW w = new WWW(URL, form);


        yield return w;

        if (w.error != null)
        {
            Debug.Log(w.error);
        }
        if (w.isDone)
        {
            Debug.Log(w.text);
            question.text = "";
            answer.text = "";
        }
        w.Dispose();
    }
}

﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AddQuestionToToets : MonoBehaviour
{
    public TextMeshProUGUI createMessage;
    public Button ToevoegenButton;
    public string Url;
    public static GameObject question;
    private GameObject toets;
    WWWForm form;

    private void Start()
    {
        createMessage.gameObject.SetActive(false);
    }

    public void AddQuestion()
    {
        try
        {
            if (QuestionSelect.toets.transform.GetChild(0).transform.GetChild(1).gameObject.GetComponent<Text>().text != "")
            {
                ToevoegenButton.interactable = false;
                toets = GameObject.Find("Toets").transform.GetChild(0).transform.GetChild(1).gameObject;
                StartCoroutine(VoegQuestionAanToets());
            }
        }
        catch
        {
            createMessage.gameObject.SetActive(true);
            createMessage.text = "Geen Question geselecteerd";
            StartCoroutine("Remove");
        }
    }

    IEnumerator VoegQuestionAanToets()
    {
        form = new WWWForm();

        question.name = question.GetComponent<Text>().text.Substring(1, question.GetComponent<Text>().text.Length - 2);
        toets.name = toets.GetComponent<Text>().text.Substring(1, toets.GetComponent<Text>().text.Length - 2);

        Debug.Log(toets.name);
        Debug.Log(question.name);

        form.AddField("Toets", toets.name);
        form.AddField("Question", question.name);

        WWW w = new WWW(Url, form);

        yield return w;

        if (w.error != null)
        {

            Debug.LogError(w.error);
        }
        else
        {
            if (w.isDone)
            {
                // als de echo een error woord bevat
                if (w.text.Contains("Error"))
                {

                    Debug.LogError(w.text);//error
                }
                else
                {
                    Debug.Log("<color=green>" + w.text + "</color>");
                    //createMessage.gameObject.SetActive(true);
                    //createMessage.text = ("<color=green>" + w.text + "</color>");
                    //RemoveCreateMessage();
                }
            }
        }

        ToevoegenButton.interactable = true;

        w.Dispose();
    }

    IEnumerator Remove()
    {
        yield return new WaitForSecondsRealtime(2f);
        createMessage.gameObject.SetActive(false);
    }
}

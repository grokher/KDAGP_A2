using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using toets;
using System;
using TMPro;

public class ToetsToQuestionsSwitch : MonoBehaviour
{
    public GameObject ToetsCanvas;
    public GameObject QuestionCanvas;
    public GameObject ToetsToevoegenCanvas;
    public InputField Toetsnaam;

    public GameObject ToetsPrefab;
    public GameObject QuestionPrefab;
    private Vector3 scaleChange;

    public string ToetsUrl;
    public string QuestionUrl;

    private void Start()
    {
        QuestionCanvas.SetActive(false);
    }

    public void onSelectClick()
    {
        try
        {
            if (ToetsSelect.toets.transform.GetChild(0).transform.GetChild(1).gameObject.GetComponent<Text>().text != "")
            {
                QuestionCanvas.SetActive(true);
                GameObject parent = GameObject.Find("ToetsContent");
                GameObject textMesh = Instantiate(ToetsSelect.toets, parent.transform);
                textMesh.name = "Toets";
                StartCoroutine(GetQuestionList());
                ToetsCanvas.SetActive(false);
            }
        }
        catch
        {
            Debug.LogError("No Toets Selected");
        }
    }

    public void back()
    {
        foreach (GameObject clone in GameObject.FindObjectsOfType(typeof(GameObject)))
        {
            if (clone.name == "Toets")
            {
                Destroy(clone);
            }
        }

        ToetsSelect.toets = null;
        ToetsCanvas.SetActive(true);
        QuestionCanvas.SetActive(false);
    }

    public void ReturnToToets()
    {
        ToetsToevoegenCanvas.SetActive(false);
        ToetsCanvas.SetActive(true);
        StartCoroutine(RefreshToets());
    }

    public void GoToToetsToevoegen()
    {
        ToetsCanvas.SetActive(false);
        ToetsToevoegenCanvas.SetActive(true);
        Toetsnaam.text = "";
    }

    IEnumerator RefreshToets()
    {

        foreach (GameObject clone in GameObject.FindObjectsOfType(typeof(GameObject)))
        {
            if (clone.name == "Toets(Clone)")
            {
                Destroy(clone);
            }
        }

        WWW w = new WWW(ToetsUrl);

        yield return w;

        if (w.isDone)
        {
            if (w.error != null)
            {
                Debug.Log(w.error);
            }
            else
            {
                //picking up data from json file
                List<Toetsinfo> userinfo = new List<Toetsinfo>(); //Hebben jullie deze dan nog wel nodig?
                if (w.text != "[]")
                {
                    string trimmedText = w.text.Remove(w.text.Length - 2, 2).Remove(0, 2);

                    string[] userinfoPieces = trimmedText.Split(new[] { "},{" }, StringSplitOptions.None);
                    for (int i = 0; i < userinfoPieces.Length; i++)
                    {
                        Toetsinfo newUserInfo = new Toetsinfo(userinfoPieces[i]);
                        userinfo.Add(newUserInfo);

                        //Debug.Log(newUserInfo);

                        scaleChange = new Vector3(1, 1, 1);

                        GameObject parent = GameObject.Find("Content");
                        //instanitiate and transforming scale so it's right
                        GameObject textMesh = Instantiate(ToetsPrefab, parent.transform);

                        //textMesh.transform.SetParent(parent.transform);

                        textMesh.transform.localScale = scaleChange;
                        //adding data to the text

                        //textMesh.GetComponent<TextMeshProUGUI>().text = user.username + "  " + user.isBlocked;
                        textMesh.GetComponentInChildren<TextMeshProUGUI>().text = newUserInfo.ToetsNaam + "  " + newUserInfo.isBlocked;

                        textMesh.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = newUserInfo.isBlocked;
                        textMesh.transform.GetChild(0).transform.GetChild(1).GetComponent<Text>().text = newUserInfo.ToetsNaam;
                    }
                }
            }
        }
        w.Dispose();
    }

    IEnumerator GetQuestionList()
    {
        WWW w = new WWW(QuestionUrl);

        yield return w;

        if (w.isDone)
        {
            if (w.error != null)
            {
                Debug.Log(w.error);
            }
            else
            {
                //picking up data from json file
                List<Questioninfo> userinfo = new List<Questioninfo>(); //Hebben jullie deze dan nog wel nodig?
                if (w.text != "[]")
                {
                    string trimmedText = w.text.Remove(w.text.Length - 2, 2).Remove(0, 2);

                    string[] userinfoPieces = trimmedText.Split(new[] { "},{" }, StringSplitOptions.None);
                    for (int i = 0; i < userinfoPieces.Length; i++)
                    {
                        Questioninfo newUserInfo = new Questioninfo(userinfoPieces[i]);
                        userinfo.Add(newUserInfo);

                        //Debug.Log(newUserInfo);

                        scaleChange = new Vector3(1, 1, 1);

                        GameObject parent = GameObject.Find("QuestionsContent");
                        //instanitiate and transforming scale so it's right
                        GameObject textMesh = Instantiate(QuestionPrefab, parent.transform);

                        //textMesh.transform.SetParent(parent.transform);

                        textMesh.transform.localScale = scaleChange;
                        //adding data to the text

                        //textMesh.GetComponent<TextMeshProUGUI>().text = user.username + "  " + user.isBlocked;
                        textMesh.GetComponentInChildren<TextMeshProUGUI>().text = newUserInfo.ToetsNaam + "  " + newUserInfo.isBlocked;

                        textMesh.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = newUserInfo.isBlocked;
                        textMesh.transform.GetChild(0).transform.GetChild(1).GetComponent<Text>().text = newUserInfo.ToetsNaam;
                    }
                }
            }
        }

        w.Dispose();
    }

    public class Questioninfo
    {
        public string ToetsNaam { set; get; }
        public string id { set; get; }
        public string isBlocked { set; get; }


        public Questioninfo(string pJsonText)
        {
            string[] dataPairs = pJsonText.Split(',');

            for (int i = 0; i < dataPairs.Length; i++)
            {
                string[] keyValuePair = dataPairs[i].Split(':');
                Debug.Assert(keyValuePair.Length == 2);

                string key = keyValuePair[0];
                string value = keyValuePair[1];

                switch (key)
                {
                    case "\"Question\"":
                        //Debug.Log("Assigning Question");
                        ToetsNaam = value;
                        break;
                    case "\"id\"":
                        //Debug.Log("Assigning id");
                        id = value;
                        break;
                }
            }
        }

        public override string ToString()
        {
            return $"username: {ToetsNaam}, id: {id}";
        }
    }
}

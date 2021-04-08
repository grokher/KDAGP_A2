using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;
using GetList;
using toets;

public class RefreshUsers : MonoBehaviour
{

    public GameObject textdata;
    private Vector3 scaleChange;

    public string Url;

    // Start is called before the first frame update
    public void refreshUsers()
    {
        StartCoroutine(RefreshUser());
    }

    public void refreshQuestion()
    {
        StartCoroutine(RefreshQuestion());
    }

    IEnumerator RefreshUser()
    {

        foreach (GameObject clone in GameObject.FindObjectsOfType(typeof(GameObject)))
        {
            if (clone.name == "Button(Clone)")
            {
                Destroy(clone);
            }
        }

        WWW w = new WWW(Url);

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
                List<Userinfo> userinfo = new List<Userinfo>(); //Hebben jullie deze dan nog wel nodig?
                if (w.text != "[]")
                {
                    string trimmedText = w.text.Remove(w.text.Length - 2, 2).Remove(0, 2);

                    string[] userinfoPieces = trimmedText.Split(new[] { "},{" }, StringSplitOptions.None);
                    for (int i = 0; i < userinfoPieces.Length; i++)
                    {
                        Userinfo newUserInfo = new Userinfo(userinfoPieces[i]);
                        userinfo.Add(newUserInfo);

                        //Debug.Log(newUserInfo);

                        scaleChange = new Vector3(1, 1, 1);

                        GameObject parent = GameObject.Find("Content");
                        //instanitiate and transforming scale so it's right
                        GameObject textMesh = Instantiate(textdata, parent.transform);

                        //textMesh.transform.SetParent(parent.transform);

                        textMesh.transform.localScale = scaleChange;
                        //adding data to the text

                        //textMesh.GetComponent<TextMeshProUGUI>().text = user.username + "  " + user.isBlocked;
                        textMesh.GetComponentInChildren<TextMeshProUGUI>().text = newUserInfo.username + "  " + newUserInfo.isBlocked;

                        textMesh.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = newUserInfo.isBlocked;
                        textMesh.transform.GetChild(0).transform.GetChild(1).GetComponent<Text>().text = newUserInfo.username;
                    }
                }
            }
        }
        w.Dispose();
    }

    IEnumerator RefreshQuestion()
    {

        foreach (GameObject clone in GameObject.FindObjectsOfType(typeof(GameObject)))
        {
            if (clone.name == "Question(Clone)")
            {
                Destroy(clone);
            }
        }

        WWW w = new WWW(Url);

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
                        GameObject textMesh = Instantiate(textdata, parent.transform);

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
                        Debug.Log("Assigning Question");
                        ToetsNaam = value;
                        break;
                    case "\"id\"":
                        Debug.Log("Assigning id");
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

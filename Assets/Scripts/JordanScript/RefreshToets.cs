using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;
using toets;

public class RefreshToets : MonoBehaviour
{

    public GameObject textdata;
    private Vector3 scaleChange;

    public string Url;

    // Start is called before the first frame update
    public void refreshUsers()
    {
        StartCoroutine(RefreshUser());
    }

    IEnumerator RefreshUser()
    {

        foreach (GameObject clone in GameObject.FindObjectsOfType(typeof(GameObject)))
        {
            if (clone.name == "Toets(Clone)")
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
}

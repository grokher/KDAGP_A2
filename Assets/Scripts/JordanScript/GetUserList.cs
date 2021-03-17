using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using Newtonsoft.Json;
using TMPro;


public class GetUserList : MonoBehaviour
{
    public string URL;
    public GameObject textdata;
    public GameObject Parent;
    private Vector3 scaleChange;
    public TextMeshProUGUI UserData;

    void Start()
    {
        StartCoroutine(GetUsersList());
    }

    IEnumerator GetUsersList()
    {
        WWW w = new WWW(URL);

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
                List<Userinfo> userinfo = new List<Userinfo>();
                userinfo = JsonConvert.DeserializeObject<List<Userinfo>>(w.text);

                foreach (var user in userinfo)
                {
                    scaleChange = new Vector3(1, 1, 1);
                  
                    GameObject parent = GameObject.Find("Content");
                    //instanitiate and transforming scale so it's right
                    GameObject textMesh = Instantiate(textdata, parent.transform);

                    //textMesh.transform.SetParent(parent.transform);

                    textMesh.transform.localScale = scaleChange;
                    //adding data to the text

                    textMesh.GetComponent<TextMeshProUGUI>().text = user.username + "  " + user.isBlocked;
                    //UserData.text = user.username + "  " + user.isBlocked;

                    Debug.Log(user.username);
                    Debug.Log(w.text);
                    //fucking dfhdshgjkdshgjedgfesdjg
                }
            }
        }
        w.Dispose();
    }
}
public class Userinfo
{
    public string username { set; get; }
    public string id { set; get; }
    public string isBlocked { set; get; }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Data;
using System.Data.SqlClient;
using System;
using Newtonsoft.Json;
using TMPro;


public class GetUserList : MonoBehaviour
{
    public string URL;
    //public Text userdata;
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
                List<Userinfo> userinfo = new List<Userinfo>();
                userinfo = JsonConvert.DeserializeObject<List<Userinfo>>(w.text);
                Debug.Log(w.text);

                foreach (var user in userinfo)
                {
                    scaleChange = new Vector3(1, 1, 1);
                  
                    GameObject parent = GameObject.Find("Content");
                    GameObject Usertext = Instantiate(textdata);
                    Usertext.transform.SetParent(parent.transform);
                    Usertext.transform.localScale = scaleChange;
                    UserData.text = user.username + "  " + user.isBlocked;
                    Debug.Log(user.username);

                    //fucking dfhdshgjkdshgjedgfesdjg

                    //Debug.Log("Name is " + user.username + " and Id is " + user.id);
                }


            }
        }
        w.Dispose();
    }

   
}

[Serializable]
public class Userinfo
{
    public string username { set; get; }
    public string id { set; get; }
    public string isBlocked { set; get; }
}

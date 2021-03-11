using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Data;
using System.Data.SqlClient;
using System;
using Newtonsoft.Json;


public class GetUserList : MonoBehaviour
{
    public string URL;
    public Text userdata;

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

                foreach (var user in userinfo)
                {
                    //MAAK GAMEOBJECT VOOR ELKE USER, GEEF HIER ID, USERNAME EN BLOCKED DOOR
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

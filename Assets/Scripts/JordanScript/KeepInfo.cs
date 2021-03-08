using System;
using System.Runtime.Serialization.Json;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeepInfo : MonoBehaviour
{
    public static LoginInfo loginInfo = new LoginInfo();

    private void Start()
    {
        if (GameObject.Find("KeepLoginInfo") == null)
        {
            DontDestroyOnLoad(this.gameObject);
        }
        
    }

    public static void JsonConvertor(WWW w)
    {
        string jsonText = w.text.Substring(1, w.text.Length - 2);
        //Debug.Log(jsonText);
        loginInfo = JsonUtility.FromJson<LoginInfo>(jsonText);
        //Debug.Log(loginInfo.username);
    }
}

[System.Serializable]
public class LoginInfo
{
    public string username;
    public string password;
    public int id;
    public string rights;
    public string isBlocked;
}

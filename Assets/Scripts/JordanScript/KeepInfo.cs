using System;
using System.Runtime.Serialization.Json;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeepInfo : MonoBehaviour
{
    public static Object test = new Object();

    private void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    public static void JsonConvertor(WWW w)
    {
        string tester = w.text;
        tester = tester.Substring(1, tester.Length - 2);
        Debug.Log(tester);
        test = JsonUtility.FromJson<Object>(tester);
        Debug.Log(test.username);
    }
}

[System.Serializable]
public class Object
{
    public string username;
    public string password;
    public int id;
    public string rights;
    public string isBlocked;
}

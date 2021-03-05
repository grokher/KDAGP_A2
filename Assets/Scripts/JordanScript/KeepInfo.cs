using System;
using System.Runtime.Serialization.Json;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeepInfo : MonoBehaviour
{
    public static void JsonConvertor(WWW w)
    {
        Debug.Log(w.text);
        string tester = w.text;
        tester = tester.Substring(1, tester.Length - 2);
        Debug.Log(tester);
        Object test = new Object();
        test = JsonUtility.FromJson<Object>(tester);
        Debug.Log(test.isBlocked);
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

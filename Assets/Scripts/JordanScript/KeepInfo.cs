using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeepInfo : MonoBehaviour
{
    public static Object JsonConvertor(WWW w)
    {
        Debug.Log(w.text);
        return JsonUtility.FromJson<Object>(w.text);
    }
}

[System.Serializable]
public class Object
{
    public string Username;
    public string Password;
    public int Id;
    public string Role;
    public string IsBlocked;
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetUserList : MonoBehaviour
{
    public string URL;

    List<string> UsersInfo = new List<string>();

    void Awake()
    {
        StartUpUserList();
    }

    void Start()
    {

    }

    public void StartUpUserList()
    {
        StartCoroutine(GetUsersList());
    }

    IEnumerator GetUsersList()
    {
        WWW w = new WWW(URL);

        yield return w;

        
        Debug.Log(w.text);
        Debug.Log(w.error);

        w.Dispose();
    }
}
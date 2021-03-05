using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetUserList : MonoBehaviour
{
    public string URL;
    public Text userdata;
    
    private List<string> UsersData = new List<string>();

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

        //UsersData.Add(w.ToString());
            yield return w;


        if (w.isDone)
        {
           
            if (w.text.Contains("Error"))
            {
                Debug.Log(w.error);
            }
            else
            {
                userdata.text = w.text;
                KeepInfo.JsonConvertor(w);
                
            }

            //Debug.Log(w.text[0][0]);

        }


        w.Dispose();
    }
}
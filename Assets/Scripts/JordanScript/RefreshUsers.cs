using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Newtonsoft.Json;
using TMPro;

public class RefreshUsers : MonoBehaviour
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
            if (clone.name == "Button(Clone)")
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

                    //textMesh.GetComponent<TextMeshProUGUI>().text = user.username + "  " + user.isBlocked;
                    textMesh.GetComponentInChildren<TextMeshProUGUI>().text = user.username + "  " + user.isBlocked;

                    textMesh.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = user.isBlocked;
                    textMesh.transform.GetChild(0).transform.GetChild(1).GetComponent<Text>().text = user.username;
                }
            }
        }
        w.Dispose();
    }
}

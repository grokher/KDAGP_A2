using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LoggedinAs : MonoBehaviour
{
    public TextMeshProUGUI logtext;
    KeepInfo keep;

    private void Start()
    {
        this.gameObject.GetComponent<Animator>().SetBool("yes", false);
        if (KeepInfo.loginInfo.username != null)
        {
            logtext.text = "Ingelogd als \n" + KeepInfo.loginInfo.username;
        }
        else
        {
            logtext.text = "Ingelogd als \n" + "Hacker";
        }
    }

    public void StartFade()
    {
        StartCoroutine("Load");
    }

    IEnumerator Load()
    {
        yield return new WaitForSeconds(3);
        this.gameObject.GetComponent<Animator>().SetBool("yes", true);
    }
}

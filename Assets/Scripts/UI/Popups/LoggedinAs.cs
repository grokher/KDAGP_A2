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
        //Zet de ingelogd window uit zicht en haalt de naam van de user op.
        this.gameObject.GetComponent<Animator>().SetBool("yes", false);
        if (KeepInfo.loginInfo.username != null)
        {
            logtext.text = "Ingelogd als \n" + KeepInfo.loginInfo.username;
        }
        else
        {
            //EASTER EGG als je in een andere scene begint of er wordt geen naam opgehaald wordt je hacker genoemd
            logtext.text = "Ingelogd als \n" + "Hacker";
        }
    }

    public void StartFade()
    {
        //Ja geen idee man. Zie ik er uit alsof i kan programmeren 
        StartCoroutine("Load");
    }

    IEnumerator Load()
    {
        //Yield een return die new is en Wait for seconds 3 keer
        yield return new WaitForSeconds(3);
        this.gameObject.GetComponent<Animator>().SetBool("yes", true);
    }
}

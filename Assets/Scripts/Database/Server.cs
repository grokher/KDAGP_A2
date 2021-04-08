using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Server : MonoBehaviour
{
	// het paneel voor als je bent ingelogd
	[SerializeField] GameObject welcomePanel;
	[SerializeField] Text user;
	[Space]
	[SerializeField] InputField username;
	[SerializeField] InputField password;
	[SerializeField] Text errorMessages;
	[SerializeField] Button loginButton;

	// de url naar de webserver met de php files (standaard verwijzing in root is naar index.php)
	[SerializeField] string url;

	// de opslag voor de data die we via de webrequest sturen
	WWWForm form;

    public bool loggedIn = false;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.KeypadEnter) || Input.GetKeyDown(KeyCode.Return))
        {
            StartCoroutine(Login());
        }
    }

    public void OnLoginButtonClicked ()
	{
		loginButton.interactable = false;
		StartCoroutine (Login ());
    }

    IEnumerator Login ()
	{
		// Creëer een nieuw form met null data
		form = new WWWForm ();


		// laad de gebruikersgegevens in de form
		form.AddField ("username", username.text);
		form.AddField ("password", password.text);

		// start een WebRequest naar de gewenste url en stuur de gegevens mee
		WWW w = new WWW (url, form);


		// wacht op antwoord van de WebRequest
		yield return w;

		// als er direct een error komt vanuit db.php
		if (w.error != null)
        {
			errorMessages.transform.parent.gameObject.SetActive(true);
			errorMessages.text = "404 not found!";
			//Debug.Log("<color=red>"+w.error+"</color>");//error
            yield return new WaitForSeconds(5);
            errorMessages.transform.parent.gameObject.SetActive(false);
        }
        else
        {
			if (w.isDone)
            {
				// als de echo een error woord bevat
				if (w.text.Contains ("error"))
                {
					errorMessages.transform.parent.gameObject.SetActive(true);
					errorMessages.text = "Je gebruikerscode of wachtwoord is niet juist";
					//Debug.Log("<color=red>"+w.text+"</color>");//error
                    yield return new WaitForSeconds(5);
                    errorMessages.transform.parent.gameObject.SetActive(false);
                }
				else if(w.text.Contains("blocked"))
                {
					errorMessages.transform.parent.gameObject.SetActive(true);
					errorMessages.text = "De User is blocked";
					//Debug.Log("<color=red>" + w.text + "</color>");//error
                    yield return new WaitForSeconds(5);
                    errorMessages.transform.parent.gameObject.SetActive(false);
                }
				else
                {
                    loggedIn = true;
					KeepInfo.JsonConvertor(w);
				}
			}
		}

		loginButton.interactable = true;

		// maak de webrequest leeg (dubbelingen voorkomen)
		w.Dispose ();
	}
}

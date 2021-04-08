using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopupOpenCollider : MonoBehaviour
{
    public GameObject
        popUpWindow,
        loadingWindow;

    public Slider loadingBar;

    [HideInInspector]
    public bool keepOpen;

    public int loadDuration = 200;

    public bool mouseOver;

    int loadingAmount;

    private void Start()
    {
        //Zet alles van de popup uit en op null 
        loadingBar.maxValue = loadDuration;
        loadingBar.gameObject.SetActive(false);
        loadingWindow.SetActive(false);
        //
    }

    private void Update()
    {
        loadingBar.value = loadingAmount;

        //Kijkt of de popupwindow open of dicht moet op basis van de muis
        if (loadingAmount == loadingBar.maxValue)
        {
            popUpWindow.GetComponent<Animator>().SetBool("open", true);
        }
        else if (keepOpen == false)
        {
            popUpWindow.GetComponent<Animator>().SetBool("open", false);
        }
        //

    }

    private void OnMouseEnter()
    {
        //houd de Popup open zolang de muis er over gaat
        keepOpen = true;
    }

    private void OnMouseOver()
    {
        loadingWindow.SetActive(true);

        //Kijkt of de muis over de loading icon gaat.
        //Daarna geeft door als je lang genoeg over de icon hovered om de window te openen
        loadingBar.gameObject.SetActive(true);
        if (loadingAmount < loadingBar.maxValue)
        {
            loadingAmount++;
            loadingWindow.SetActive(true);
        }
        //
    }

    private void OnMouseExit()
    {
        //Reset als de muis de Popup verlaat
        loadingWindow.SetActive(false);
        loadingBar.gameObject.SetActive(false);
        loadingAmount = 0;
        //
    }
}

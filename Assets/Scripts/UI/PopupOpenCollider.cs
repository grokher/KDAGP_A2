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
        loadingBar.maxValue = loadDuration;
        loadingBar.gameObject.SetActive(false);
        loadingWindow.SetActive(false);
    }

    private void Update()
    {
        loadingBar.value = loadingAmount;

        if (loadingAmount == loadingBar.maxValue)
        {
            popUpWindow.GetComponent<Animator>().SetBool("open", true);
        }
        else if (keepOpen == false)
        {
            popUpWindow.GetComponent<Animator>().SetBool("open", false);
        }

    }

    private void OnMouseEnter()
    {
        keepOpen = true;
    }

    private void OnMouseOver()
    {
        Debug.Log("Over");
        loadingWindow.SetActive(true);
        

        loadingBar.gameObject.SetActive(true);
        if (loadingAmount < loadingBar.maxValue)
        {
            loadingAmount++;
            loadingWindow.SetActive(true);
        }
    }

    private void OnMouseExit()
    {
        loadingWindow.SetActive(false);
        loadingBar.gameObject.SetActive(false);
        loadingAmount = 0;
    }
}

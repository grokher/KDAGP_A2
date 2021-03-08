using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FilterButtons : MonoBehaviour
{
    public List<GameObject> StudentButtons = new List<GameObject>();
    public List<GameObject> OtherButtons = new List<GameObject>();

    private void Awake()
    {
        foreach(GameObject button in StudentButtons)
        {
            button.SetActive(false);
        }

        if (KeepInfo.loginInfo.rights == "Student")
        {
            foreach(GameObject button in StudentButtons)
            {
                button.SetActive(true);
            }
            foreach(GameObject button in OtherButtons)
            {
                button.SetActive(false);
            }
        }
        else
        {
            foreach (GameObject button in StudentButtons)
            {
                button.SetActive(false);
            }
            foreach (GameObject button in OtherButtons)
            {
                button.SetActive(true);
            }
        }
    }
}

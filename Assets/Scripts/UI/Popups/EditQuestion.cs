using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class EditQuestion : MonoBehaviour
{
    GameObject editWindow;

    [SerializeField]
    PopupTextManager ppM;


    TextMeshProUGUI question;
    TextMeshProUGUI number, bar, description, b1, b2, b3, b4;
    Button[] buttons;

    private void Start()
    {
        editWindow = GameObject.Find("Question Box Teacher");

        question = ppM.question;
        number = ppM.number;
        bar = ppM.bar;
        description = ppM.description;
        b1 = ppM.b1;
        b2 = ppM.b2;
        b3 = ppM.b3;
        b4 = ppM.b4;
        buttons = ppM.buttons;
    }

    public void WindowSet(bool set)
    {
        editWindow.gameObject.SetActive(set);
    }


}

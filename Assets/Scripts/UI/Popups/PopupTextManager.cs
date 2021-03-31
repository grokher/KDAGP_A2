using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PopupTextManager : MonoBehaviour
{
    [SerializeField, Header("It's like al the texteses on the Popup :D")]
    
    public TextMeshProUGUI question;
    public TextMeshProUGUI number, bar, description, b1, b2, b3, b4;
    public Button[] buttons;

    private void Start()
    {

    }

    public void WrongAwnser()
    {

    }

    public void RightAwnser()
    {

    }
}

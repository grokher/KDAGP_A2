using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FilterButtons : MonoBehaviour
{
    public List<GameObject> Buttons = new List<GameObject>();
    public List<string> studentButtons = new List<string>();
    public List<string> otherButtons = new List<string>();
    public List<Button.ButtonClickedEvent> studentEvents = new List<Button.ButtonClickedEvent>();
    public List<Button.ButtonClickedEvent> otherEvents = new List<Button.ButtonClickedEvent>();
    private void Awake()
    {
        if (KeepInfo.loginInfo.rights == "Student")
        {
            for (int i = 0; i < Buttons.Count; i++)
            {
                Debug.Log(i.ToString());
                if (i + 1 > studentButtons.Count)
                {
                    Buttons[i].SetActive(false);
                }
                else { 
                Buttons[i].GetComponentInChildren<Text>().text = studentButtons[i];
                Buttons[i].GetComponent<Button>().onClick = studentEvents[i];
                }
            }           
        }
        else
        {            
            for (int i = 0; i < Buttons.Count; i++)
            {
                Buttons[i].GetComponentInChildren<Text>().text = otherButtons[i];
                Buttons[i].GetComponent<Button>().onClick = otherEvents[i];
            }           
        }
    }
    /*void ButtonFunction()
    {
        if (KeepInfo.loginInfo.rights == "Student")
        {
            for (int i = 0; i < Buttons.Count; i++)
            {
                Buttons[i].GetComponentInChildren<Text>().text = studentButtons[i];
                Buttons[i].GetComponent<Button>().onClick = buttonEvents[i];
            }
        }
        else
        {
            for (int i = 3; i < Buttons.Count; i++)
            {
                Buttons[i].GetComponentInChildren<Text>().text = otherButtons[i];
                Buttons[i].GetComponent<Button>().onClick = buttonEvents[i];
            }
        }
    }*/
}

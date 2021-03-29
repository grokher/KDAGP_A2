using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToetsToQuestionsSwitch : MonoBehaviour
{
    public GameObject ToetsCanvas;
    public GameObject QuestionCanvas;

    private void Start()
    {
        QuestionCanvas.SetActive(false);
    }

    public void onSelectClick()
    {
        ToetsCanvas.SetActive(false);
        QuestionCanvas.SetActive(true);
    }

    public void back()
    {
        ToetsCanvas.SetActive(true);
        QuestionCanvas.SetActive(false);
    }
}

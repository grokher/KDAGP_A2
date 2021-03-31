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
        QuestionCanvas.SetActive(true);
        GameObject parent = GameObject.Find("ToetsContent");
        GameObject textMesh = Instantiate(ToetsSelect.toets, parent.transform);
        textMesh.name = "Toets";
        ToetsCanvas.SetActive(false);
    }

    public void back()
    {
        foreach (GameObject clone in GameObject.FindObjectsOfType(typeof(GameObject)))
        {
            if (clone.name == "Toets")
            {
                Destroy(clone);
            }
        }

        ToetsCanvas.SetActive(true);
        QuestionCanvas.SetActive(false);
    }
}

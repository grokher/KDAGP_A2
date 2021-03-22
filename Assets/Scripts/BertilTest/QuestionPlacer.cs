using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QuestionPlacer : MonoBehaviour
{
    public GameObject[] questionTypes;
    Quaternion rot;
    Vector3 worldPosition;

    GameObject placingText;

    bool placeWindow;

    Slider sizeField;
    int awnsers;
    int qN;

    Dropdown format;

    void Start()
    {
        rot = this.gameObject.transform.rotation;
        format = GameObject.Find("FormatSelecor").GetComponent<Dropdown>();
        sizeField = GameObject.Find("Questions").GetComponent<Slider>();
        placingText = GameObject.Find("PlacingText");
        try
        {
            placingText.SetActive(false);
        }
        catch(Exception E)
        {

        }
    }

    public void Update()
    {
        if (placeWindow)
        {
            placingText.SetActive(true);
            OnClick();
        }
    }

    public void MakeQuestion()
    {
        ManageQuestionFormat();
    }

    void ManageQuestionFormat()
    {
        try
        {
            awnsers = (int)sizeField.value;
            placeWindow = true;
        }
        catch (Exception e)
        {
            Debug.LogWarning("Hmmmm it seems some idiot isnt using A NUMBER WHAT THE FUCK YOU BUCKET");
        }
    }

    void OnClick()
    {
        if (awnsers == 2)
        {
            qN = 1;
        }
        if (awnsers == 3)
        {
            qN = 2;
        }
        if (awnsers == 4)
        {
            qN = 3;
        }
        if (Input.GetKey(KeyCode.Mouse0) && qN != 0)
        {
            PlaceObjectAtMouse(questionTypes[(qN - 1)]);
            placingText.SetActive(false);
            placeWindow = false;

        }

        qN = 0;
    }

    void PlaceObjectAtMouse(GameObject placeObj)
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitData;

        if (Physics.Raycast(ray, out hitData, 1000))
        {
            worldPosition = hitData.point;
            GameObject newWindow = Instantiate(placeObj, worldPosition, rot);

            newWindow.name = placeObj.name;

            this.gameObject.GetComponent<DatatSaver>().SavePosition(newWindow.gameObject);
        }
    }
}

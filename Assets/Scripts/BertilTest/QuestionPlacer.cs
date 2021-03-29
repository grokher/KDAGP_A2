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
    DatatSaver dataSaver;

    GameObject placingText;

    bool placeWindow;

    Slider sizeField;
    int awnsers;
    int qN;

    Dropdown format;

    void Start()
    {
        dataSaver = this.gameObject.GetComponent<DatatSaver>();
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
        placingText.SetActive(placeWindow);
        if (placeWindow)
        {
            
            OnClick();
            if (Input.GetKeyDown(KeyCode.Mouse1))
            {
                placeWindow = false;
            }
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
            
            placeWindow = false;

        }

        qN = 0;
    }

    public void InstantiateQuestion(string name, Transform position)
    {
        foreach (GameObject question in questionTypes)
        {
            if(question.name == name)
            {
                GameObject newWindow = Instantiate(question, position);
                newWindow.transform.SetParent(null);


                newWindow.name = question.name;

                dataSaver.SavePosition(newWindow.gameObject);
            }
        }
    }

    void PlaceObjectAtMouse(GameObject placeObj)
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitData;

        if (Physics.Raycast(ray, out hitData, 1000))
        {
            if (hitData.transform.gameObject.CompareTag("PlacableSurface"))
            {
                worldPosition = hitData.point;
                GameObject newWindow = Instantiate(placeObj, worldPosition, rot);

                newWindow.name = placeObj.name;

                dataSaver.SavePosition(newWindow.gameObject);

            } else
            {
                Debug.Log("INVAAALIIID");
            }
        }
    }
}

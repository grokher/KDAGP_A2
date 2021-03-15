using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestionPlacer : MonoBehaviour
{
    public GameObject[] questionTypes;
    Quaternion rot;
    Vector3 worldPosition;
    bool buildingMode;

    int qN;

    InputField sizeField;
    int awnsers;

    Dropdown format;

    void Start()
    {
        rot = this.gameObject.transform.rotation;
        format = GameObject.Find("FormatSelecor").GetComponent<Dropdown>();
        sizeField = GameObject.Find("AwnserAmount").GetComponent<InputField>();
    }

    public void MakeQuestion()
    {
        ManageQuestionFormat();
    }

    void ManageQuestionFormat()
    {
        try
        {
            awnsers = int.Parse(sizeField.text);
        }
        catch (Exception e)
        {
            Debug.LogWarning("Hmmmm it seems some idiot isnt using A NUMBER WHAT THE FUCK YOU BUCKET");
        }
    }

    void OnClick()
    {
        if (Input.GetKey(KeyCode.Mouse0) && buildingMode && qN != 0)
        {
            PlaceObjectAtMouse(questionTypes[qN]);
        }
    }

    void PlaceObjectAtMouse(GameObject placeObj)
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitData;

        if (Physics.Raycast(ray, out hitData, 1000))
        {
            worldPosition = hitData.point;
            Instantiate(placeObj, worldPosition, rot);
        }
    }
}

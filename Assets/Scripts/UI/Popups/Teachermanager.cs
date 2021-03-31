using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teachermanager : MonoBehaviour
{
    [SerializeField, Header("The parent of the Question")]
    GameObject parentObject;

    [SerializeField]
    GameObject sureWindow;

    public void USure(bool set)
    {
        sureWindow.SetActive(set);
    }

    public void DeleteQuestion()
    {
        Destroy(parentObject);
    }
}

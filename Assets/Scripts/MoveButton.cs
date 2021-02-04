using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveButton : MonoBehaviour
{
    enum buttonTypes
    {
        moveToNextArea,
        moveToPreviousArea
    }
    [SerializeField] buttonTypes buttonType;

    GameObject UIElement;

    Vector2 originalUISize;
    Vector3 originalButtonSize;

    [HideInInspector] public bool hasRun;

    private void Start()
    {
        transform.LookAt(Camera.main.transform);
        Raycasting.current.interactionTriggerd += HasInteracted;

        SetUI(false);
        hasRun = true;
    }
    private void SetUI(bool status)
    {
        if (UIElement != null)
        {
            UIElement.SetActive(status);
        }
    }

    private void HasInteracted(string name)
    {
        if (this.transform.name == name)
        {
            switch ((int)buttonType + 1)
            {
                case 1:
                    MoveToNextArea();
                    break;
                case 2:
                    MoveToPreviousArea();
                    break;
            }
        }
    }
    public  void MoveToNextArea()
    {
        if (nextareaInfo.nextArea.GetComponentInChildren<MoveButton>().hasRun != true)
        {
            SetUI(true);
        }
        this.transform.parent.gameObject.SetActive(false);
        nextareaInfo.nextArea.SetActive(true);
        

        RenderSettings.skybox = nextareaInfo.SkyBox;
    }

    public  void MoveToPreviousArea()
    {
        if (previousareaInfo.previousArea.GetComponentInChildren<MoveButton>().hasRun != true)
        {
            SetUI(true);
        }
        this.transform.parent.gameObject.SetActive(false);
        previousareaInfo.previousArea.SetActive(true);
        

        RenderSettings.skybox = previousareaInfo.skybox2;
    }

    [System.Serializable]
    public struct NextArea
    {
        public GameObject nextArea;
        public Material SkyBox;
    }
    [Space, SerializeField] NextArea nextareaInfo;

    [System.Serializable]

    public struct PreviousArea
    {
        public GameObject previousArea;
        public Material skybox2;
    }
    [Space, SerializeField] PreviousArea previousareaInfo;
}
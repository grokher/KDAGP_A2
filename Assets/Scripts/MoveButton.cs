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
    Transform UISize;

    Vector2 originalUISize;
    Vector3 originalButtonSize;

    [HideInInspector] public bool hasRun;

    private void Awake()
    {
        UIElement = GameObject.FindObjectOfType<Canvas>().gameObject;
        UISize = UIElement.transform.GetChild(0).transform;

        originalButtonSize = this.transform.localScale;
    }

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
        if (this.transform.name == name && !UIElement.activeInHierarchy)
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
    private void MoveToNextArea()
    {
        if (nextareaInfo.nextArea.GetComponentInChildren<MoveButton>().hasRun != true)
        {
            SetUI(true);
        }
        nextareaInfo.nextArea.SetActive(true);
        this.transform.parent.gameObject.SetActive(false);

        RenderSettings.skybox = nextareaInfo.SkyBox;
    }

    private void MoveToPreviousArea()
    {
        if (previousareaInfo.previousArea.GetComponentInChildren<MoveButton>().hasRun != true)
        {
            SetUI(true);
        }
        Debug.Log(previousareaInfo.previousArea.name);
        previousareaInfo.previousArea.SetActive(true);
        this.transform.parent.gameObject.SetActive(false);

        RenderSettings.skybox = previousareaInfo.Skybox;
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
        public Material Skybox;
    }
    [Space, SerializeField] PreviousArea previousareaInfo;
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildingMode : MonoBehaviour
{
    Canvas buildingWindow;

    public GameObject[] mcBuild;
    public GameObject[] openBuild;
    public GameObject[] infoBuild;

    public Animator anim;

    Dropdown selector;

    bool windowState = true;

    int lastDrop;

    private void Start()
    {
        selector = GameObject.Find("FormatSelecor").GetComponent<Dropdown>();
        buildingWindow = this.gameObject.GetComponent<Canvas>();
        lastDrop = selector.value;
        SetWindow();
        WindowManager(selector.value);
    }

    private void Update()
    {
        if(lastDrop != selector.value)
        {
            WindowManager(selector.value);
            lastDrop = selector.value;
        }
    }

    public void SetWindow()
    {
        windowState = !windowState;
        anim.SetBool("openWindow", windowState);
    }

    void WindowManager(int on)
    {
        EasyIf(mcBuild, false);
        EasyIf(openBuild, false);
        EasyIf(infoBuild, false);

        switch (on)
        {
            case 0:
                EasyIf(mcBuild, true);
                break;

            case 1:
                EasyIf(openBuild, true);
                break;

            case 2:
                EasyIf(infoBuild, true);
                break;
        }

    }

    void EasyIf(GameObject[] array, bool onOff)
    {
        for (int i = 0; i < array.Length;)
        {
            if(array[i] != null)
            {
                array[i].SetActive(onOff);
            }
            i++;
        }
    }
}

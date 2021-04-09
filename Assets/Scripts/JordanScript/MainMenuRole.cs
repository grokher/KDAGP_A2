using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuRole : MonoBehaviour
{
    public GameObject ToetsMenu;
    public GameObject Bewerker;

    void Start()
    {
        if (KeepInfo.loginInfo.rights == "Student")
        {
            ToetsMenu.SetActive(false);
            Bewerker.SetActive(false);
        }
    }

}

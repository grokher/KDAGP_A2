using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class DropdownMenuManager : MonoBehaviour
{
    [SerializeField]
    Image Menu;
    [SerializeField]
    bool isOpen;
    // Start is called before the first frame update
    void Start()
    {
        Menu.gameObject.SetActive(false);   
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    public void OpenMenu()
    {
        Menu.gameObject.SetActive(true);
        Menu.gameObject.GetComponent<Animator>().SetBool("MenuOpen", true);
    }
    public void CloseMenu()
    {
        Menu.gameObject.GetComponent<Animator>().SetBool("MenuOpen", false);
    }
    public void MenuButton()
    {
        if (isOpen)
        {
            CloseMenu();
            isOpen = false;
        }
        else
        {
            OpenMenu();
            isOpen = true;
        }
    }
    public void ChangeScene(string name)
    {
        SceneManager.LoadScene(name);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DropdownMenuManager : MonoBehaviour
{
    [SerializeField]
    Image Menu;
    // Start is called before the first frame update
    void Start()
    {
        
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
}

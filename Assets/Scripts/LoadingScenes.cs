using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingScenes : MonoBehaviour
{           
    public GameObject loggedInPanel;
    Scene currentscene;

    private void Start()
    {
        currentscene = SceneManager.GetActiveScene();
        loggedInPanel = GameObject.Find("CreateUserPanel");
        loggedInPanel.SetActive(false);
    }
    public void LoadCreateScene()
    {
        SceneManager.LoadScene("createUserScene");
    }
    public void LoadLoginScene()
    {
        SceneManager.LoadScene("LoginScreen");
    }
    public void LoadServerScene()
    {
        SceneManager.LoadScene("Nathans scene");
    }
    public void EnableCreateUI() 
    {
        loggedInPanel.SetActive(true);
    }
    public void DisableCreateUI()
    {
        loggedInPanel.SetActive(false);
    }
    void Update()
    {
        if (currentscene.name == ("LoginScreen"))
        {
            if (loggedInPanel.activeInHierarchy == true)
            {
                StartCoroutine(Load());
            }
        }

        

    }
    IEnumerator Load()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("Nathans scene");
    }
}

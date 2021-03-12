using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingScenes : MonoBehaviour
{           
    public GameObject loggedInPanel;
    public GameObject createPanel;
    Scene currentscene;

    private void Awake()
    {
        createPanel = GameObject.Find("CreateUserPanel");
        if (createPanel != null) 
        { createPanel.SetActive(false); }
    }

    private void Start()
    {
        currentscene = SceneManager.GetActiveScene();
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
        createPanel.SetActive(true);
    }
    public void DisableCreateUI()
    {
        createPanel.SetActive(false);
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingScenes : MonoBehaviour
{
    public GameObject loggedInPanel;
    public void LoadCreateScene()
    {
        SceneManager.LoadScene("createUserScene");
    }
    public void LoadLoginScene()
    {
        SceneManager.LoadScene("LoginScreen");
    }
    void Update()
    {
        if (loggedInPanel.activeInHierarchy == true)
        {
            StartCoroutine(Load());
        }

    }
    IEnumerator Load()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("Davids scene");
    }
}

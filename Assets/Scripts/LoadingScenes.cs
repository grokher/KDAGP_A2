using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingScenes : MonoBehaviour
{           
    public GameObject loggedInPanel;
    public GameObject createPanel;
    public GameObject blockPanel;
    public GameObject uploadPanel;
    public GameObject questionBox;
    public GameObject ButtonMenu;
    Scene currentscene;
    bool menuState = false;

    private void Awake()
    {
        uploadPanel.SetActive(false);
        createPanel = GameObject.Find("CreateUserPanel");
        if (createPanel != null) 
        { createPanel.SetActive(false); }
        blockPanel = GameObject.Find("BlockUserPanel");
        if (blockPanel != null) 
        { blockPanel.SetActive(false); }
        questionBox = GameObject.Find("QuestionBoxTeacher");
        if(questionBox != null)
        { questionBox.SetActive(false); }
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

    public void LoadFunnyScene()
    {
        SceneManager.LoadScene("Bram Scene");
    }
    public void EnableCreateUI() 
    {
        createPanel.SetActive(true);
        ButtonMenu.SetActive(false);
    }
    public void EnablePhotoUI()
    {
        uploadPanel.SetActive(true);
        ButtonMenu.SetActive(false);
    }
    public void DisablePhotoUI()
    {
        uploadPanel.SetActive(false);
        ButtonMenu.SetActive(true);
    }
    public void DisableCreateUI()
    {
        createPanel.SetActive(false);
        ButtonMenu.SetActive(true);
    }
     public void EnableBlockUI() 
    {
        blockPanel.SetActive(true);
    }
    public void DisableBlockUI()
    {
        blockPanel.SetActive(false);
    }
    public void LoadBlockingScene()
    {
        SceneManager.LoadScene("BlockUser");
    }

    public void LoadMenuScene()
    {
        SceneManager.LoadScene("StartMenu");
    }

    public void EnableQuestionUI()
    {
        questionBox.SetActive(true);
        ButtonMenu.SetActive(false);
    }
    public void DisableQuestionUI()
    {
        questionBox.SetActive(false);
        ButtonMenu.SetActive(true);
    }
    void Update()
    {
        if (currentscene.name == ("LoginScreen"))
        {
            Server sS = GameObject.Find("GameController").GetComponent<Server>();
            if (sS.loggedIn == true)
            {
                SceneManager.LoadScene("StartMenu");
            }
        }

        

    }
    IEnumerator Load()
    {
        yield return new WaitForSeconds(3);
    }
}

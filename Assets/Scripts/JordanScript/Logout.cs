using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Logout : MonoBehaviour
{
    public void logout(string Scene)
    {
        KeepInfo.loginInfo = new LoginInfo();
        SceneManager.LoadScene(Scene);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMove : MonoBehaviour
{
    public void MoveScene(string _sceneName)
    {
        SceneManager.LoadScene(_sceneName);
        Debug.Log("�� �̵�");
    }

    public void ExitApp()
    {
        Application.Quit();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MySceneManager : MonoBehaviour
{
    // Use this for initialization
    void Start()
    {}

    public void LoadNewSceneWithIndex(int index)
    {
        SceneManager.LoadScene(SceneManager.GetSceneAt(index).ToString(), LoadSceneMode.Single);
    }

    public void LoadNewSceneWithName(string name)
    {
        SceneManager.LoadScene(name, LoadSceneMode.Single);
    }

    public void QuiteGame()
    {
        Application.Quit();
    }
}

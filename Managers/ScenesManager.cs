using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class ScenesManager : MonoBehaviour
{
    public void LoadMainMenu()
    {
        SceneManager.LoadScene("StartMenu");

    }

    public void LoadScene1()
    {
        SceneManager.LoadScene("SampleScene");
        Time.timeScale = 1f;
    }

}

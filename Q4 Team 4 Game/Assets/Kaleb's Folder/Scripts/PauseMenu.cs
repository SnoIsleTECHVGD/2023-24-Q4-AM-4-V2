using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pausemenu;
    public GameObject settingsmenu;
    public bool isPaused = false;
    public bool isSettings = false;
    void Start()
    {
        pausemenu.SetActive(false);
        settingsmenu.SetActive(false);
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) && isSettings == false)
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }

    }

    public void PauseGame()
    {
        pausemenu.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void ResumeGame()
    {
        pausemenu.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }
    public void Settings()
    {
        isPaused = false;
        isSettings = true;
        Time.timeScale = 0f;
        pausemenu.SetActive(false);
        settingsmenu.SetActive(true);
    }

    public void Back()
    {
        isPaused = true;
        isSettings = false;
        pausemenu.SetActive(true);
        settingsmenu.SetActive(false);
    }
}

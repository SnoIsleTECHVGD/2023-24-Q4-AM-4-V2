using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pausemenu;
    public GameObject tutorialmenu;
    public GameObject button;
    public GameObject phozForward;
    public GameObject phozBackward;
    public GameObject mainMenuButton;
    public bool isPaused = false;
    public bool isSettings = false;
    public bool isTutorial = false;
    private int noteint = 1;
    private string nam;
    Scene scene;
    public GameObject pNotes1, pNotes2, pNotes3, pNotes4, pNotes5, pNotes6, pNotes7;
    void Start()
    {
        pausemenu.SetActive(false);
        tutorialmenu.SetActive(false);
        phozBackward.SetActive(false);
        phozForward.SetActive(false);
        pNotes1.SetActive(false);
        pNotes2.SetActive(false);
        pNotes3.SetActive(false);
        pNotes4.SetActive(false);
        pNotes5.SetActive(false);
        pNotes6.SetActive(false);
        pNotes7.SetActive(false);
    }

    void Update()
    {
        scene = SceneManager.GetActiveScene();
        nam = scene.name;
        if (nam == "Opening Scene")
        {
            pNotes1.SetActive(true);
            Tutorial();
        }
        if (!isTutorial)
        {
            tutorialmenu.SetActive(false);
        }
        if(Input.GetKeyDown(KeyCode.Escape) && isTutorial == false)
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
        if (noteint > 7 || noteint < 0)
        {
            noteint = 1;
        }
        if (noteint == 1 || !isTutorial)
        {
            phozBackward.SetActive(false);
        }
        else
        {
            phozBackward.SetActive(true);
        }
        if (noteint == 7 || !isTutorial)
        {
            phozForward.SetActive(false);
        }
        else
        {
            phozForward.SetActive(true);
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
    public void Back()
    {
        isPaused = true;
        isSettings = false;
        isTutorial = false;
        pausemenu.SetActive(true);
        tutorialmenu.SetActive(false);
        pNotes1.SetActive(false);
        pNotes2.SetActive(false);
        pNotes3.SetActive(false);
        pNotes4.SetActive(false);
        pNotes5.SetActive(false);
        pNotes6.SetActive(false);
        pNotes7.SetActive(false);
    }

    public void Tutorial()
    {
        isPaused = false;
        isTutorial = true;
        Time.timeScale = 0f;
        pausemenu.SetActive(false);
        tutorialmenu.SetActive(true);
    }
    public void PhozForward()
    {
        noteint += 1;
    }
    public void PhozBackward()
    {
        noteint -= 1;
    }
    public void phozNoteSet()
    {
        if (noteint == 1)
        {
            pNotes1.SetActive(true);
            pNotes2.SetActive(false);
        }
        if (noteint == 2)
        {
            pNotes1.SetActive(false);
            pNotes2.SetActive(true);
            pNotes3.SetActive(false);
        }
        if (noteint == 3)
        {
            pNotes2.SetActive(false);
            pNotes3.SetActive(true);
            pNotes4.SetActive(false);
        }
        if (noteint == 4)
        {
            pNotes3.SetActive(false);
            pNotes4.SetActive(true);
            pNotes5.SetActive(false);
        }
        if (noteint == 5)
        {
            pNotes4.SetActive(false);
            pNotes5.SetActive(true);
            pNotes6.SetActive(false);
        }
        if (noteint == 6)
        {
            pNotes5.SetActive(false);
            pNotes6.SetActive(true);
            pNotes7.SetActive(false);
        }
        if (noteint == 7)
        {
            pNotes6.SetActive(false);
            pNotes7.SetActive(true);
            mainMenuButton.SetActive(true);
        }
    }
    public void PhozStart()
    {
        button.SetActive(true);
    }
}

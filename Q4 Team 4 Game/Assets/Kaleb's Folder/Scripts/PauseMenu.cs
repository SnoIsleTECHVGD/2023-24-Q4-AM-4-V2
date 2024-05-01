using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pausemenu;
    public GameObject settingsmenu;
    public GameObject tutorialmenu;
    private GameObject note;
    public bool isPaused = false;
    public bool isSettings = false;
    public bool isTutorial = false;
    private int noteint = 1;
    private string nota;
    public GameObject pNotes1, pNotes2, pNotes3, pNotes4, pNotes5, pNotes6, pNotes7;
    void Start()
    {
        pausemenu.SetActive(false);
        settingsmenu.SetActive(false);
        tutorialmenu.SetActive(false);
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
        isTutorial = false;
        pausemenu.SetActive(true);
        settingsmenu.SetActive(false);
        tutorialmenu.SetActive(false);
    }

    public void Tutorial()
    {
        isPaused = false;
        isTutorial = true;
        Time.timeScale = 0f;
        pausemenu.SetActive(false);
        tutorialmenu.SetActive(true);
    }
    public void phozBackward()
    {
        note.SetActive(false);
        noteint -= 1;
        nota = "pNotes" + noteint;
        note = GameObject.Find(nota);
        note.SetActive(true);
    }
    public void phozForward()
    {
        note.SetActive(false);
        noteint += 1;
        nota = "pNotes" + noteint;
        note = GameObject.Find(nota);
        note.SetActive(true);
    }
    public void phozStart()
    {
        nota = "Phoz Notes " + noteint;
        Debug.Log(nota);
        note = GameObject.Find(nota);
        note.SetActive(true);
        //pNotes1.SetActive(true);
    }
}

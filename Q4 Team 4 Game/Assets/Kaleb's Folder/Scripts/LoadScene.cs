using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    Scene scene;
    public static string nam = "Hola! Como Estas! Donde esta la biblioteca!";
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void MainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Title Scene");
    }

    public void Credits()
    {
        scene = SceneManager.GetActiveScene();
        Time.timeScale = 1f;
        SceneManager.LoadScene("Credits Scene");
        nam = scene.name;
    }

    public void PCredits()
    {
        SceneManager.LoadScene("Credits Scene");
    }

    public void KCredits()
    {
        SceneManager.LoadScene("Kaleb's Credits");
    }

    public void DCredits()
    {
        SceneManager.LoadScene("Damon's Credits");
    }

    public void JCredits()
    {
        SceneManager.LoadScene("Joshua's Credits");
    }

    public void HCredits()
    {
        SceneManager.LoadScene("Hannah's Credits");
    }

    public void SCredits()
    {
        SceneManager.LoadScene("Siena's Credits");
    }

    public void ReturnFromCredits()
    {
        SceneManager.LoadScene(nam);
    }

    public void Settings()
    {
        scene = SceneManager.GetActiveScene();
        Time.timeScale = 1f;
        nam = scene.name;
        SceneManager.LoadScene("Settings");
    }

    public void Play()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Main Scene");
    }

    public void Quit()
    {
        Time.timeScale = 1f;
        Application.Quit();
    }
}

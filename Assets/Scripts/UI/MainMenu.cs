using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayButton()
    {
        SceneManager.LoadScene("Cutscene1");
        Time.timeScale = 1.0f;
    }
    public void QuitButton()
    {
        Application.Quit();
    }

    public void LevelsButton()
    {
        SceneManager.LoadScene("Levels");
    }

    public void StartButton()
    {
        SceneManager.LoadScene("Tutorial");
        Time.timeScale = 1f;
    }

    public void HomeButton()
    {
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1f;
    }


    public void Cutscene2Button()
    {
        SceneManager.LoadScene("Cutscene2");
        Time.timeScale = 1.0f;
    }

    public void Cutscene3Button()
    {
        SceneManager.LoadScene("Cutscene3");
        Time.timeScale = 1.0f;
    }

    public void Cutscene4Button()
    {
        SceneManager.LoadScene("Cutscene4");
        Time.timeScale = 1.0f;
    }

    public void Cutscene5Button()
    {
        SceneManager.LoadScene("Cutscene5");
        Time.timeScale = 1.0f;
    }

    public void Cutscene6Button()
    {
        SceneManager.LoadScene("Cutscene6");
        Time.timeScale = 1.0f;
    }

    public void Cutscene7Button()
    {
        SceneManager.LoadScene("Cutscene7");
        Time.timeScale = 1.0f;
    }

    public void Cutscene8Button()
    {
        SceneManager.LoadScene("Cutscene8");
        Time.timeScale = 1.0f;
    }

    public void Cutscene9Button()
    {
        SceneManager.LoadScene("Cutscene9");
        Time.timeScale = 1.0f;
    }

    public void Level1Button()
    {
        SceneManager.LoadScene("Level1");
        Time.timeScale = 1.0f;
    }

    public void Level2Button()
    {
        SceneManager.LoadScene("Level2");
        Time.timeScale = 1.0f;
    }

    public void Level3Button()
    {
        SceneManager.LoadScene("Level3");
        Time.timeScale = 1.0f;
    }

    public void Level4Button()
    {
        SceneManager.LoadScene("Level4");
        Time.timeScale = 1.0f;
    }

    public void Level5Button()
    {
        SceneManager.LoadScene("Level5");
        Time.timeScale = 1.0f;
    }

}

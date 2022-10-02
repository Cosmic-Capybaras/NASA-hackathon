using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    public void playGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void back()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);

    }

    public void guessGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }

    public void samplegame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);

    }
    public void duelgame()
    {
        SceneManager.LoadScene("Duel");

    }
    public void botgame()
    {
        SceneManager.LoadScene("Bot");

    }

    public void quitGame()
    {
        Application.Quit();

    }

    public void backFromSample()
    {
        SceneManager.LoadScene("menu-mods");

    }

    public void backFromGues()
    {
        SceneManager.LoadScene("menu-mods");
    }

    public void openLibrary()
    {
        SceneManager.LoadScene("library");
    }

}

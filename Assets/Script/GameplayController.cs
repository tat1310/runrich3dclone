using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameplayController : MonoBehaviour
{
    public GameObject winPanel;
    public GameObject losePanel;

    private void Start()
    {
        Time.timeScale = 1f;
    }
    public void TaptoplayButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Time.timeScale = 1f;
    }
    public void ExitButton()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1f;
    }
    public void PlayAgain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
    }
    public void NextLv()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Time.timeScale = 1f;
    }
    public void NextLvCuoi()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1f;
    }
    public void ExitWinButton()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1f;
    }
}

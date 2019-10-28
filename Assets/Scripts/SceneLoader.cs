using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour {

	public void NextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void MainMenu()
    {
        FindObjectOfType<GameStatus>().NewGame();
        SceneManager.LoadScene("Main Menu");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void NewGame()
    {
        FindObjectOfType<GameStatus>().NewGame();
        SceneManager.LoadScene("Main Game");
    }

    public void GameOver()
    {
        SceneManager.LoadScene("Game Over");
    }
}

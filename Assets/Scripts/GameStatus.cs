using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameStatus : MonoBehaviour {

    [Range(0f,2f)]
    [SerializeField]
    float gameSpeed = 1f;

    [SerializeField]
    int breakableBlocks = 0;

    [SerializeField]
    int score = 0;

    [SerializeField]
    int scoreIncreasePerBlock = 50;

    [SerializeField]
    int totalStartingLives = 3;

    [SerializeField]
    int totalLives;

    [SerializeField]
    TextMeshProUGUI scoreText;

    private void Awake()
    {
        if (FindObjectsOfType<GameStatus>().Length > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Start()
    {
        totalLives = totalStartingLives;
        scoreText.text = score.ToString();
    }

    // Update is called once per frame
    void Update () {
        Time.timeScale = gameSpeed;
	}

    public void CountBreakableBlocks()
    {
        breakableBlocks++;
    }

    public void DestroyBreakableBlock()
    {
        breakableBlocks--;
        score += scoreIncreasePerBlock;
        scoreText.text = score.ToString();

        if (breakableBlocks <= 0)
        {
            FindObjectOfType<SceneLoader>().NextScene();
        }
    }

    public void LoseLife()
    {
        totalLives--;
        if (totalLives <= 0)
        {
            FindObjectOfType<SceneLoader>().GameOver();
        }
    }

    public void NewGame()
    {
        Destroy(gameObject);
    }
}

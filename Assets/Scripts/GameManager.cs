using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int score = 0;
    public int lives = 3;

    public bool gameOver = true;

    public Text scoreText;
    public Text livesText;
    public GameObject gameScreen;
    public GameObject gameOverScreen;
    public Text gameOverScoreText;

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    private void Update()
    {
        if(lives <= 0)
        {
            gameOver = true;
            FruitSpawner.instance.StopSpawning();
            GameOver();
        }
    }
    public void UpdateScore()
    {
        score++;
        scoreText.text = "SCORE: " + score;
    }

    public void Updatelives()
    {
        lives--;
        livesText.text = lives.ToString();
    }

    public void GameOver()
    {
        gameScreen.SetActive(false);
        gameOverScreen.SetActive(true);
        gameOverScoreText.text = score.ToString();
    }

    public void PlayAgainBtn()
    {
        lives = 4;
        Updatelives();
        score = -1;
        UpdateScore();
        gameOver = false;

        FruitSpawner.instance.StartGame();
    }
    public void MenuBtn()
    {
        SceneManager.LoadScene(0);
    }

    public void quitBtn()
    {
        Application.Quit();
    }
}

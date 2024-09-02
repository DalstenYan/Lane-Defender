using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    InputActionReference restart;
    [SerializeField]
    PlayerTank player;
    [SerializeField]
    EnemySpawning spawners;

    [SerializeField]
    float lives = 3f;
    [SerializeField]
    float score = 0;
    [SerializeField]
    float highscore;

    bool betterScore = false;

    [SerializeField]
    TextMeshProUGUI livesDisplay;
    [SerializeField]
    TextMeshProUGUI scoreDisplay;
    [SerializeField]
    TextMeshProUGUI highscoreDisplay;

    [SerializeField]
    GameObject deathScreen;
    [SerializeField]
    TextMeshProUGUI betterScoreDisplay;
    [SerializeField]
    TextMeshProUGUI deathScoreDisplay;
    [SerializeField]
    TextMeshProUGUI deathHighscoreDisplay;

    public float Score { get => score; set => score = value; }

    private void Awake()
    {
        highscore = PlayerPrefs.GetFloat("Highscore");
        deathScreen.SetActive(false);
        betterScoreDisplay.gameObject.SetActive(false);
        livesDisplay.text = lives.ToString();
        highscoreDisplay.text = highscore.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (restart.action.triggered)
            Restart();
    }

    public void Restart()
    {
        SceneManager.LoadScene("MainGame");
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void SubtractLives()
    {
        lives--;
        livesDisplay.text = lives.ToString();
        if (lives == 0)
            Death();
    }
    public void AddScore(float sc) 
    {
        score += sc;
        scoreDisplay.text = score.ToString();
        if (score > highscore)
            UpdateHighscore();
    }
    public void UpdateHighscore() 
    {
        highscore = score;
        highscoreDisplay.text = highscore.ToString();
        betterScore = true;
    }
    void Death() 
    {
        PlayerPrefs.SetFloat("Highscore", highscore);
        player.gameObject.SetActive(false);
        spawners.gameObject.SetActive(false);
        deathScreen.SetActive(true);
        betterScoreDisplay.gameObject.SetActive(betterScore);
        deathScoreDisplay.text = score.ToString();
        deathHighscoreDisplay.text = highscore.ToString();  


    }
}

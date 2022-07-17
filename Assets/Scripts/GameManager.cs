using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{

    [SerializeField] private bool debug;
    
    [SerializeField] private GameObject enemySpawner;
    [SerializeField] private GameObject itemSpawner;
    [SerializeField] private GameObject walkToStartText;
    [SerializeField] private GameObject scoreText;
    [SerializeField] private GameObject highScoreText;
    [SerializeField] private GameObject gameOverText;

    private AudioSource audioSource;

    public static GameManager instance;
    public bool gameStart = false;

    private float score = 0f; 
        
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        audioSource = GetComponent<AudioSource>();
    }
    void Start()
    {
        highScoreText.GetComponent<TMP_Text>().text = PlayerPrefs.GetInt("HighScore").ToString();
    }
    void Update()
    {
        if ((Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0))
        {
            enemySpawner.SetActive(true);
            itemSpawner.SetActive(true);
            scoreText.SetActive(true);
            walkToStartText.SetActive(false);
            highScoreText.SetActive(false);
            gameStart = true;
        }
        if (gameStart == true)
        {
            score += Time.deltaTime;
            scoreText.GetComponent<TMP_Text>().text = ((int)score).ToString();
        }
        RestartGame();
    }
    private void RestartGame()
    {
        if (Input.GetKeyDown(KeyCode.R)) 
        {
            Input.ResetInputAxes();
            HighScore();
            SceneManager.LoadScene("Scene");
            Time.timeScale = 1f;
        }   
    }
    public void GameOver()
    {
        if (debug)
            return;
        audioSource.PlayOneShot(audioSource.clip);
        Time.timeScale = 0f;
        gameOverText.SetActive(true);
    }

    public void HighScore()
    {
        int highScore = PlayerPrefs.GetInt("HighScore");
        if (highScore < (int)score)
        {
            PlayerPrefs.SetInt("HighScore", (int)score);
        }   
    }
}

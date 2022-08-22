using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{

    [SerializeField] private bool debug;

    [SerializeField] private float adsRate;

    [SerializeField] private GameObject enemySpawner;
    [SerializeField] private GameObject itemSpawner;
    [SerializeField] private GameObject walkToStartText;
    [SerializeField] private GameObject scoreText;
    [SerializeField] private GameObject highScoreText;
    [SerializeField] private GameObject restartButton;
    [SerializeField] private GameObject reviveButton;
    private int revive = 0;

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
        if (Player.instance.movement.magnitude != 0)
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
    }
    public void RestartGame()
    {
        HighScore();
        if (Random.Range(0f,1f) <= adsRate && revive == 0)
            AdsManager.instance.PlayAd();
        SceneManager.LoadScene("Scene");
        Time.timeScale = 1f; 
    }
    public void Revive()
    {
        AdsManager.instance.PlayRewardedAd(ReviveCallBack);
    }
    public void ReviveCallBack()
    {
        revive++;
        restartButton.SetActive(false);
        reviveButton.SetActive(false);
        Player.instance.Revive();
        Time.timeScale = 1f;
    }
    public void GameOver()
    {
        if (debug)
            return;
        audioSource.PlayOneShot(audioSource.clip);
        Time.timeScale = 0f;
        restartButton.SetActive(true);
        if(revive == 0)
        {
            reviveButton.SetActive(true);
        }
        else
        {
            reviveButton.SetActive(false);
        }
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

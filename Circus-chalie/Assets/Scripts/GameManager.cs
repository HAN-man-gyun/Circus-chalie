using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public Image life1;
    public Image life2;
    public Image life3;

    public TextMeshProUGUI Score;
    public TextMeshProUGUI HighScore;

    public bool isGameover = false;
    public int score = 0;
    private int highScore = 0;
    public int life = 3;
    // Start is called before the first frame update

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Debug.LogWarning("씬에 두개 이상의 게임매니저가 존재합니다.");
            Destroy(gameObject);
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isGameover && Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        Score.text = "1P-" + score;
        if(highScore<score)
        {
            highScore = score;
            PlayerPrefs.SetFloat("HighScore", highScore);
        }

        if(life == 2) {
            life3.enabled = false;
        }
        if(life == 1) {
            life2.enabled = false;
        }
        if(life == 0) {
            life1.enabled = false;
        }
    }

    public void AddScore(int newScore)
    {
        if(!isGameover )
        {
            score += newScore;
        }
    }

    public void OnPlayerDead()
    {
        isGameover = true;
    }
}

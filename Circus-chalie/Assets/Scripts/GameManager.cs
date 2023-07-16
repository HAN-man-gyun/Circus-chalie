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
    public GameObject End;
    public GameObject End2;
    public GameObject End3;


    public int meter = 10;
    public Image life1;
    public Image life2;
    public Image life3;

    public TMP_Text Score;
    public TMP_Text HighScore;
    //public TextMeshProUGUI GameOver;
    public GameObject GameOver;
    public GameObject GameClear;

    public bool isGameover = false;
    public int score = 0;
    private int highScore = 0;
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
        isGameover = false;
        HighScore.text = "HI-" + (PlayerPrefs.GetFloat("HighScore"));
    }

    // Update is called once per frame
    void Update()
    {
        if(meter==90)
        {
            End.SetActive(false);
            End2.SetActive(true);
            End3.SetActive(true);
        }
 
           

        Score.text = "1P-" + score;
        if(highScore<score)
        {
            highScore = score;
            PlayerPrefs.SetFloat("HighScore", highScore);
        }

        if(Static.life == 2) {
            life3.enabled = false;
        }
        if(Static.life == 1) {
            life3.enabled = false;
            life2.enabled = false;
        }
        if(Static.life == 0) {
            life3.enabled = false;
            life2.enabled = false;
            life1.enabled = false;
        }
    }


    public void OnPlayerDead()
    {
        isGameover = true;
        Debug.Log("플레이어데드");
        GameOver.SetActive(true);
        
    }

    public void OnClearGame()
    {
        isGameover = true;
        GameClear.SetActive(true);
    }

    public void Restart()
    {
        

        if(Static.life ==0)
        {
            SceneManager.LoadScene("TitleScene");
        }
        else
        {
            SceneManager.LoadScene("SampleScene");
        }
    }
}

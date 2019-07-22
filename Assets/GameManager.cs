using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] Text myScoreText;
    [SerializeField] Text myTimer;
    [Header("GameOver Panel")]
    [SerializeField] GameObject myPanel;
    [SerializeField] Text myScoreTextPanel;
    [SerializeField] float timer = 30f;
    float myScore = 0f;
    bool isGameEnd = false;

    private void Awake()
    {
        myPanel.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        if(isGameEnd) { return; }
        myTimer.text = Mathf.RoundToInt(Time.realtimeSinceStartup).ToString();
        myScoreText.text = myScore.ToString();
    }
    public void IncreaseScore(float amount)
    {
        myScore += amount;
    }
    public void GameEnd()
    {
        myPanel.SetActive(true);
        Time.timeScale = 0;
        myScoreTextPanel.text = "Score :" + myScore.ToString();
        isGameEnd = true;
    }
    public void RestartGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}

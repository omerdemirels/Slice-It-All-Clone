using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] Text scoreText;
    [SerializeField] Text highScoreTextNextLevel;
    private int score;
    private int highScore;
    [SerializeField] int levelScore;
    GameManager gameManager;

    private void Awake()
    {

        gameManager = FindObjectOfType<GameManager>();
        HighScoreUpdate();
    }
    /// <summary>
    /// Score ekrana yans�t�r.
    /// </summary>
    /// <param name="stairs"></param>
    public void ScoreUpdate(int stairs)
    {
        score += stairs;
        Debug.Log(score);
        scoreText.text = "Score: " + score.ToString();
        if (score >= highScore)
        {
            //gameManager.gameOver = true;
            //StartCoroutine(Next());
            highScore = score;
            HighScoreUpdate();
        }

    }
    IEnumerator Next()
    {
        yield return new WaitForSeconds(2f);
        gameManager.NextLevel();
    }


    /// <summary>
    /// En y�ksek Score Hesaplama
    /// </summary>
    public void HighScoreUpdate()
    {

        if (PlayerPrefs.HasKey("highscore" + gameManager.SceneIndex))
        {
            if (PlayerPrefs.GetInt("highscore" + gameManager.SceneIndex) <= highScore)
            {
                PlayerPrefs.SetInt("highscore" + gameManager.SceneIndex, highScore);

            }

        }
        else
        {
            PlayerPrefs.SetInt("highscore" + gameManager.SceneIndex, 0);
        }

        highScoreTextNextLevel.text = "High Score: " + PlayerPrefs.GetInt("highscore" + gameManager.SceneIndex);
        
    }
}


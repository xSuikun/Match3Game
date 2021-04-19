using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextRefresher : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    [SerializeField] private Text scoreText;
    [SerializeField] private Text movesText;
    [SerializeField] private Text previousResultText;
    [SerializeField] private Text bestRecordText;

    public void RefreshScore()
    {
        scoreText.text = "Score: " + gameManager.Score.ToString();
    }

    public void RefreshMoves()
    {
        movesText.text = "Moves: " + gameManager.Moves.ToString();
    }

    public void RefreshPlayerStats()
    {
        previousResultText.text = "Previous Score: \n" + gameManager.Score.ToString();
        bestRecordText.text = "Best Record: \n" + PlayerPrefs.GetInt("Best Record").ToString();
    }
}

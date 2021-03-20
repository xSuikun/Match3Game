using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{
    [SerializeField] private Text scoreText;
    public Text ScoreText
    {
        get
        {
            return scoreText;
        }
    }

    [SerializeField] private Text movesText;
    public Text MovesText
    {
        get
        {
            return movesText;
        }
    }

    [SerializeField] private Text previousResultText;
    public Text PreviousResultText
    {
        get
        {
            return previousResultText;
        }
    }

    [SerializeField] private Text bestRecordText;
    public Text BestRecordText
    {
        get
        {
            return bestRecordText;
        }
    }

    [SerializeField] private GameObject gameOverPanel;
    public GameObject GameOverPanel
    {
        get
        {
            return gameOverPanel;
        }
    }
}

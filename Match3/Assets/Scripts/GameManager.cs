using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class GameManager : MonoBehaviour
{
    [SerializeField] private BoardGenerator boardGenerator;
    [SerializeField] private BoardSettings boardSettings;
    [SerializeField] private ClearBoardSystem clearBoardSystem;
    [SerializeField] private GameUI gameUI;

    void Start()
    {
        clearBoardSystem.SetupSettings(boardSettings.xSize, boardSettings.ySize, boardSettings.tileSprites);
        boardGenerator.SetupSettings(boardSettings.xSize, boardSettings.ySize, boardSettings.tileSprites);
        boardGenerator.GenerateBoard();
        clearBoardSystem.SetTileGrid(boardGenerator.tileGrid);
    }

    private int score = 0;
    private int moves = 10;

    public void AddScore(int combo)
    {
        int value;
        if (combo <= 3)
            value = 200;
        else if (combo == 4)
            value = 400;
        else
            value = 800;

        score += value;
        gameUI.ScoreText.text = "Score: " + score.ToString();
    }

    public void DecreaseMoves()
    {
        moves --;
        gameUI.MovesText.text = "Moves: " + moves.ToString();

        if (moves <= 0)
            GameOver();
    }

    public void ContinueGameForAd()
    {
        moves += 10;
        gameUI.GameOverPanel.SetActive(false);
    }

    private void GameOver()
    {
        if (score > PlayerPrefs.GetInt("Score"))
        {
            PlayerPrefs.SetInt("Score", score);
            gameUI.BestRecordText.text = "New record: " + PlayerPrefs.GetInt("Score").ToString();
        }
        else
        {
            gameUI.BestRecordText.text = "Best Record: \n" + PlayerPrefs.GetInt("Score").ToString();
        }

        gameUI.PreviousResultText.text = "Previous Score: \n" + score.ToString();

        gameUI.GameOverPanel.SetActive(true);
    }
}

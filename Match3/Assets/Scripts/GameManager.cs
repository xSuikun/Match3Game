using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int Score { get; private set; }
    public int Moves { get; private set; }

    [SerializeField] private ClearBoardSystem clearBoardSystem;
    [SerializeField] private BoardSettings boardSettings;
    [SerializeField] private BoardGenerator boardGenerator;
    [SerializeField] private TextRefresher textRefresher;
    [SerializeField] private StatsSaver statsSaver;
    [SerializeField] private AnalyticsScript analyticsScript;
    [SerializeField] private GameObject gameOverPanel;

    private int adsPerSession;

    void Start()
    {
        boardGenerator.GenerateBoard();
        clearBoardSystem.SetTileGrid(boardGenerator.tileGrid);

        Score = 0;
        Moves = 10;
    }

    public void AddScore(int combo)
    {
        int value;
        if (combo <= 3)
            value = 200;
        else if (combo == 4)
            value = 400;
        else
            value = 800;

        Score += value;
        textRefresher.RefreshScore();
    }

    public void DecreaseMoves()
    {
        Moves--;
        textRefresher.RefreshMoves();

        if (Moves <= 0)
            ShowGameOverScreen();
    }

    public void ContinueGame()
    {
        Moves += 10;
        textRefresher.RefreshMoves();
        gameOverPanel.SetActive(false);
    }

    private void ShowGameOverScreen()
    {
        statsSaver.CheckIfNewRecord();
        textRefresher.RefreshPlayerStats();
        analyticsScript.OnGameOver(Score, adsPerSession);
        gameOverPanel.SetActive(true);
    }

    public void OnAdWatched() => adsPerSession++;
}

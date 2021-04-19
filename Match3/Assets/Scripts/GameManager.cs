using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class GameManager : MonoBehaviour
{
    [SerializeField] private ClearBoardSystem clearBoardSystem;
    [SerializeField] private BoardSettings boardSettings;
    [SerializeField] private BoardGenerator boardGenerator;
    [SerializeField] private TextRefresher textRefresher;
    [SerializeField] private StatsSaver statsSaver;

    [SerializeField] private GameObject gameOverPanel;

    public int Score { get; private set; }
    public int Moves { get; private set; }

    void Start()
    {
        clearBoardSystem.SetupSettings(boardSettings.xSize, boardSettings.ySize, boardSettings.tileSprites);
        boardGenerator.SetupSettings(boardSettings.xSize, boardSettings.ySize, boardSettings.tileSprites);
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
        gameOverPanel.SetActive(true);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverButtons : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;

    public void RestartButton() => SceneManager.LoadScene("Game");

    public void MenuButton() => SceneManager.LoadScene("Menu");

    public void ContunueGameButton() => gameManager.ContinueGameForAd();
}

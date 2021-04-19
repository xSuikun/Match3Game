using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatsSaver : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;

    public void CheckIfNewRecord()
    {
        if (gameManager.Score > PlayerPrefs.GetInt("Best Record"))
        {
            PlayerPrefs.SetInt("Best Record", gameManager.Score);
        }
    }
}

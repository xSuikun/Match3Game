using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

public class AnalyticsScript : MonoBehaviour
{
    public void OnGameOver(int score, int adsPerSession)
    {
        Analytics.CustomEvent("GameOverAnalytics", new Dictionary<string, object>()
        {
            {"Score", score},
            {"AdsPerSession", adsPerSession}
        });
    }
}

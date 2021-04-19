using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.UI;

public class RewardedAdsButton : MonoBehaviour, IUnityAdsListener
{
    [SerializeField] private GameManager gameManager;

    private Button button;

    private string gameId = "4054379";
    private string rewardedPlacementId = "rewardedVideo";

    void Start()
    {
        button = GetComponent<Button>();

        button.interactable = Advertisement.IsReady(rewardedPlacementId);

        if (button) button.onClick.AddListener(ShowRewardedVideo);

        Advertisement.AddListener(this);
        Advertisement.Initialize(gameId, true);
    }

    public void ShowRewardedVideo()
    {
        if (Advertisement.IsReady(rewardedPlacementId))
        {
            Advertisement.Show(rewardedPlacementId);
        }
    }

    public void OnUnityAdsReady(string placementId)
    {
        if (placementId == rewardedPlacementId)
        {
            button.interactable = true;
        }
    }

    public void OnUnityAdsDidError(string message)
    {
        Debug.Log("UnityAds did error!");
    }

    public void OnUnityAdsDidStart(string placementId)
    {
        Debug.Log("Ads did start.");
    }

    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
        if (showResult == ShowResult.Finished)
        {
            gameManager.ContinueGame();
        }
        else if (showResult == ShowResult.Failed)
        {
            Debug.Log("The ad did not finish due to an error.");
        }
    }

    private void OnDestroy()
    {
        Advertisement.RemoveListener(this);
    }
}

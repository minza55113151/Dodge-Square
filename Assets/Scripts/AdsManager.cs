using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
using System;

public class AdsManager : MonoBehaviour, IUnityAdsListener
{
    public static AdsManager instance;
    #if UNITY_IOS
        string gameId = "4892002";
    #else
        string gameId = "4892003";
    #endif

    private Action onRewardedAdsSuccess;
    
    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        Advertisement.Initialize(gameId);
        Advertisement.AddListener(this);
    }
    public void PlayAd()
    {
        if (Advertisement.IsReady("Interstitial_Android"))
        {
            Advertisement.Show("Interstitial_Android");
        }
    }
    public void PlayRewardedAd(Action onSuccess)
    {
        if (Advertisement.IsReady("Rewarded_Android"))
        {
            onRewardedAdsSuccess = onSuccess;
            Advertisement.Show("Rewarded_Android");
        }
    }

    public void OnUnityAdsReady(string placementId)
    {
        Debug.Log(placementId + " ready");
    }

    public void OnUnityAdsDidError(string message)
    {
        Debug.Log("Error: " + message);
    }

    public void OnUnityAdsDidStart(string placementId)
    {
        Debug.Log(placementId + " start");
        BackGroundMusic.instance.audioSource.mute = !BackGroundMusic.instance.audioSource.mute;


    }

    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
        BackGroundMusic.instance.audioSource.mute = !BackGroundMusic.instance.audioSource.mute;
        if (placementId == "Rewarded_Android" && showResult == ShowResult.Finished)
        {
            onRewardedAdsSuccess.Invoke();
        } 
    }
}

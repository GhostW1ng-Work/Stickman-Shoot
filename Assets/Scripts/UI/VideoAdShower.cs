using System;
using UnityEngine;
using UnityEngine.Events;

public class VideoAdShower : MonoBehaviour
{
    public event UnityAction VideoShowed;
    public event UnityAction VideoClosed;

    public void OnShowVideoAd()
    {
#if !UNITY_EDITOR && UNITY_WEBGL
        Agava.YandexGames.VideoAd.Show(null, GiveReward, OnCloseVideo);
#else
        VideoShowed?.Invoke();
#endif


    }

    private void GiveReward()
    {
        VideoShowed?.Invoke();
    }

    private void OnCloseVideo()
    {
        VideoClosed?.Invoke();
    }
}

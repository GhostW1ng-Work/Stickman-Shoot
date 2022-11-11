using System;
using UnityEngine;
using UnityEngine.Events;

public class VideoAdShower : MonoBehaviour
{
    public event UnityAction VideoShowed;
    public Action onActionComplete;

    public void OnShowVideoAd()
    {
#if !UNITY_EDITOR && UNITY_WEBGL
        Agava.YandexGames.VideoAd.Show(null, null, GiveReward);
#else
        VideoShowed?.Invoke();
#endif


    }

    private void GiveReward()
    {
        VideoShowed?.Invoke();
    }
}

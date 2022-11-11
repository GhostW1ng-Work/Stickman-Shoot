using System;
using UnityEngine;
using UnityEngine.Events;

public class VideoAdShower : MonoBehaviour
{
    public event UnityAction VideoShowed;
    public Action onActionComplete;

    public void OnShowVideoAd()
    {
        //Agava.YandexGames.VideoAd.Show(null,null,GiveReward);
        VideoShowed?.Invoke();
    }

    private void GiveReward()
    {
        VideoShowed?.Invoke();
    }
}

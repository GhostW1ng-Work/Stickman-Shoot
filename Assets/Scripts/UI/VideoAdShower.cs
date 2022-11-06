using UnityEngine;
using UnityEngine.Events;

public class VideoAdShower : MonoBehaviour
{
    public event UnityAction VideoShowed;

    public void OnShowVideoAd()
    {
        Agava.YandexGames.VideoAd.Show();
        VideoShowed?.Invoke();
    }
}

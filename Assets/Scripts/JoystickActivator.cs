using UnityEngine;

public class JoystickActivator : MonoBehaviour
{
    [SerializeField] private VideoAdShower _videoAdShower;

    private void OnEnable()
    {
        _videoAdShower.VideoShowed += OnVideoShowed;
    }

    private void OnDisable()
    {
        _videoAdShower.VideoShowed -= OnVideoShowed;
    }

    private void Start()
    {
        _videoAdShower.VideoShowed += OnVideoShowed;
    }

    private void OnVideoShowed()
    {
#if !UNITY_EDITOR && UNITY_WEBGL
 if (Agava.YandexGames.Device.Type == Agava.YandexGames.DeviceType.Mobile)
        {
            gameObject.SetActive(true);
        }
#endif
    }
}

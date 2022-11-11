using UnityEngine;

public class JoystickActivator : MonoBehaviour
{
    [SerializeField] private VideoAdShower _videoAdShower;
    [SerializeField] private PlayerFaller _playerFaller;

    private void OnEnable()
    {
        _videoAdShower.VideoShowed += OnVideoShowed;
        _playerFaller.PlayerFalled += DisableJoystick;
    }

    private void OnDisable()
    {
        _videoAdShower.VideoShowed -= OnVideoShowed;
        _playerFaller.PlayerFalled -= DisableJoystick;
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

    private void DisableJoystick()
    {
        gameObject.SetActive(false);
    }
}

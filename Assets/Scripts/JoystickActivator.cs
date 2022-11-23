using System.Collections;
using UnityEngine;

public class JoystickActivator : MonoBehaviour
{
    [SerializeField] private VideoAdShower _videoAdShower;
    [SerializeField] private PlayerFaller _playerFaller;
    [SerializeField] private FloatingJoystick _joyStick;

    private void OnEnable()
    {
        _videoAdShower.VideoShowed += OnVideoShowed;
        _playerFaller.PlayerFalled += DisableJoystick;
        PlayerToIslandTeleporter.TeleportStarted += DisableJoystick;
        PlayerToIslandTeleporter.TeleportEnded += OnTeleportEnded;
    }

    private void OnDisable()
    {
        _videoAdShower.VideoShowed -= OnVideoShowed;
        _playerFaller.PlayerFalled -= DisableJoystick;
        PlayerToIslandTeleporter.TeleportStarted -= DisableJoystick;
        PlayerToIslandTeleporter.TeleportEnded -= OnTeleportEnded;
    }

    private void OnVideoShowed()
    {
#if !UNITY_EDITOR && UNITY_WEBGL
 if (Agava.YandexGames.Device.Type == Agava.YandexGames.DeviceType.Mobile)
        {
            _joyStick.enabled = true;
        }
#else
        _joyStick.enabled = true;
        

#endif
    }

    private void DisableJoystick()
    {
        _joyStick.enabled = false;
        _joyStick.OnPointerUp();
    }

    private void OnTeleportEnded()
    {
        _joyStick.OnPointerUp();
        StartCoroutine(WaitForEnable());
    }

    private IEnumerator WaitForEnable()
    {
        yield return new WaitForSeconds(0.5f);
        OnVideoShowed();
    }
}

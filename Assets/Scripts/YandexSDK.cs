using Agava.YandexGames;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class YandexSDK : MonoBehaviour
{
    [SerializeField] private Text _authorizationStatusText;
    [SerializeField] private Text _personalProfileDataPermissionStatusText;
    [SerializeField] private JoystickActivator _joystick;

    private void Awake()
    {
        YandexGamesSdk.CallbackLogging = true;
    }

    private IEnumerator Start()
    {
#if !UNITY_EDITOR && UNITY_WEBGL
        yield return YandexGamesSdk.Initialize();

        if(Agava.YandexGames.Device.Type == Agava.YandexGames.DeviceType.Desktop)
        {
            _joystick.gameObject.SetActive(false);
        }
        
        while (true)
        {
            _authorizationStatusText.color = PlayerAccount.IsAuthorized ? Color.green : Color.red;

            if (PlayerAccount.IsAuthorized)
                _personalProfileDataPermissionStatusText.color = PlayerAccount.HasPersonalProfileDataPermission ? Color.green : Color.red;
            else
                _personalProfileDataPermissionStatusText.color = Color.red;

            yield return new WaitForSecondsRealtime(0.25f);
        }
#else
        yield break;
#endif
    }
}



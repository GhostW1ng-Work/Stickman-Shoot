using Agava.YandexGames;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using Cinemachine;

public class YandexSDK : MonoBehaviour
{
    [SerializeField] private Text _authorizationStatusText;
    [SerializeField] private Text _personalProfileDataPermissionStatusText;
    [SerializeField] private JoystickActivator _joystick;
    [SerializeField] private DesktopMover _desktopMover;
    [SerializeField] private MobileMover _mobileMover;
    [SerializeField] private CinemachineVirtualCamera _virtualCamera;
    [SerializeField] private float _fieldOfViewMobile;

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
            _virtualCamera.m_Lens.FieldOfView = 60;
            _joystick.gameObject.SetActive(false);
            _mobileMover.enabled = false;
        }
        else if(Agava.YandexGames.Device.Type == Agava.YandexGames.DeviceType.Mobile)
        {
            _virtualCamera.m_Lens.FieldOfView = _fieldOfViewMobile;
            _desktopMover.enabled = false;
        }
        
        while (true)
        {
            _authorizationStatusText.color = PlayerAccount.IsAuthorized ? Color.green : Color.red;

            if (PlayerAccount.IsAuthorized)
            {
               
                _personalProfileDataPermissionStatusText.color = PlayerAccount.HasPersonalProfileDataPermission ? Color.green : Color.red;
            }

            else
                _personalProfileDataPermissionStatusText.color = Color.red;

            yield return new WaitForSecondsRealtime(0.25f);
        }
#else
        yield break;
#endif
    }

    public void Authorize()
    {
        PlayerAccount.Authorize();
    }

    public void RequestPersonalProfileDataPermission()
    {
        PlayerAccount.RequestPersonalProfileDataPermission();
    }
}



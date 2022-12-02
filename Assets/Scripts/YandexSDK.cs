using Agava.YandexGames;
using System.Collections;
using UnityEngine;
using Cinemachine;

public class YandexSDK : MonoBehaviour
{
    [SerializeField] private FloatingJoystick _joystick;
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

        switch (YandexGamesSdk.Environment.i18n.lang)
        {
            case "ru":
                Lean.Localization.LeanLocalization.SetCurrentLanguageAll("Russian");
                break;
            case "en":
                Lean.Localization.LeanLocalization.SetCurrentLanguageAll("English");
                break;
            case "tr":
                Lean.Localization.LeanLocalization.SetCurrentLanguageAll("Turkish");
                break;
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



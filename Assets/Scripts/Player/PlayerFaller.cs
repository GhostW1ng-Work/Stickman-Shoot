using System.Collections;
using UnityEngine;

public class PlayerFaller : MonoBehaviour
{
    [SerializeField] private GameObject _joystick;
    [SerializeField] private VideoAdShower _videoAdShower;

    private Rigidbody _rigidBody;
    private MobileMover _mobileMover;
    private DesktopMover _desktopMover;

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
        _rigidBody = GetComponent<Rigidbody>();
        _mobileMover = GetComponent<MobileMover>();
        _desktopMover = GetComponent<DesktopMover>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.TryGetComponent(out Ground ground))
        {
            transform.rotation = new Quaternion(0, 0, 0, 0);
            _rigidBody.constraints = RigidbodyConstraints.FreezeRotation | RigidbodyConstraints.FreezePositionY;

            _mobileMover.enabled = true;
            _desktopMover.enabled = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.transform.TryGetComponent(out Ground ground))
        {
            _rigidBody.constraints = RigidbodyConstraints.None;
            _mobileMover.enabled = false;
            _desktopMover.enabled = false;
            _joystick.SetActive(false);
        }
    }

    private void OnVideoShowed()
    {
#if !UNITY_EDITOR && UNITY_WEBGL
     if(Agava.YandexGames.Device.Type == Agava.YandexGames.DeviceType.Desktop)
        {
            _desktopMover.enabled = true;
        }
        else if(Agava.YandexGames.Device.Type == Agava.YandexGames.DeviceType.Mobile)
        {
            _mobileMover.enabled = true;
        }
#endif
        transform.rotation = new Quaternion(0, 0, 0, 0);
        _rigidBody.constraints = RigidbodyConstraints.FreezeRotation | RigidbodyConstraints.FreezePositionY;
    }
}

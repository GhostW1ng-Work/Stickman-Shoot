using System.Collections;
using UnityEngine;

public class MoverActivator : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private DesktopMover _desktopMover;
    [SerializeField] private MobileMover _mobileMover;
    [SerializeField] private PlayerFaller _playerFaller;
    [SerializeField] private VideoAdShower _videoAdShower;
    [SerializeField] private Rigidbody _rigidBody;
    [SerializeField] private float _timeToGiveControl;

    private void OnEnable()
    {
        _player.AntiFreezed += EnableMover;
        _player.Freezed += DisableMover;
        _playerFaller.PlayerFalled += DisableMover;
        _videoAdShower.VideoShowed += EnableMover;
        PlayerToIslandTeleporter.TeleportEnded += EnableMover;
    }

    private void OnDisable()
    {
        _player.AntiFreezed -= EnableMover;
        _player.Freezed -= DisableMover;
        _playerFaller.PlayerFalled -= DisableMover;
        _videoAdShower.VideoShowed -= EnableMover;
        PlayerToIslandTeleporter.TeleportEnded -= EnableMover;
    }

    private void EnableMover()
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
#else
        _mobileMover.enabled = true;
        _desktopMover.enabled = true;
#endif
    }

    private void DisableMover()
    {
        _mobileMover.enabled = false;
        _desktopMover.enabled = false;
    }

    private void OnTeleportEnded()
    {
        StartCoroutine(WaitForTeleportEnded());
    }

    private IEnumerator WaitForTeleportEnded()
    {
        yield return new WaitForSeconds(_timeToGiveControl);
        EnableMover();
    }
}

using System.Collections.Generic;
using UnityEngine;

public class PlayerResurrector : MonoBehaviour
{
    [SerializeField] private VideoAdShower _videoAdShower;
    [SerializeField] private AudioSource _ressurectSound;
    [SerializeField] private Player _player;
    [SerializeField] private List<Transform> _spawnPointsTransform;

    private Transform _currentSpawnPosition;

    private void OnEnable()
    {
        _videoAdShower.VideoShowed += OnVideoAdShowed;
        PlayerToIslandTeleporter.TeleportEnded += OnTeleportEnded;
    }

    private void OnDisable()
    {
        _videoAdShower.VideoShowed -= OnVideoAdShowed;
        PlayerToIslandTeleporter.TeleportEnded -= OnTeleportEnded;
    }

    private void Start()
    {
        _currentSpawnPosition = _spawnPointsTransform[0];
    }

    private void OnVideoAdShowed()
    {
        _ressurectSound.Play();
        _player.gameObject.SetActive(true);
        _player.transform.position = _currentSpawnPosition.position;
    }

    private void OnTeleportEnded()
    {
        _currentSpawnPosition = _spawnPointsTransform[1];
    }
}

using System.Collections.Generic;
using UnityEngine;

public class PlayerResurrector : MonoBehaviour
{
    [SerializeField] private VideoAdShower _videoAdShower;
    [SerializeField] private AudioSource _ressurectSound;
    [SerializeField] private Player _player;
    [SerializeField] private List<Transform> _spawnPointsTransform;

    private Transform _currentSpawnPosition;
    private int _currentSpawnPositionIndex;

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
        _currentSpawnPositionIndex = 0;
        _currentSpawnPosition = _spawnPointsTransform[_currentSpawnPositionIndex];
    }

    private void OnVideoAdShowed()
    {
        _ressurectSound.Play();
        _player.gameObject.SetActive(true);
        _player.transform.position = _currentSpawnPosition.position;
    }

    private void OnTeleportEnded()
    {
        _currentSpawnPositionIndex++;
        _currentSpawnPosition = _spawnPointsTransform[_currentSpawnPositionIndex];
    }
}

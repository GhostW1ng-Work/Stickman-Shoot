using UnityEngine;
using Cinemachine;

public class CameraSwitcher : MonoBehaviour
{
    [SerializeField] EnemyOnArenaCounter _enemyOnArenaCounter;
    [SerializeField] private CinemachineVirtualCamera _currentCamera;
    [SerializeField] private CinemachineVirtualCamera _nextCamera;

    private void OnEnable()
    {
        _enemyOnArenaCounter.EnemiesOnArenaDied += OnEnemiesOnAreaDied;
    }

    private void OnDisable()
    {
        _enemyOnArenaCounter.EnemiesOnArenaDied -= OnEnemiesOnAreaDied;
    }

    private void OnEnemiesOnAreaDied()
    {
        _currentCamera.Priority = 0;
        _nextCamera.Priority = 10;
    }
}

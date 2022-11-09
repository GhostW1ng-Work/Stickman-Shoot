using UnityEngine;
using Cinemachine;

public class CameraSwitcher : MonoBehaviour
{
    [SerializeField] EnemyOnArenaCounter _enemyOnArenaCounter;
    [SerializeField] private CinemachineVirtualCamera _secondCamera;

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
        _secondCamera.Priority = 20;
    }
}

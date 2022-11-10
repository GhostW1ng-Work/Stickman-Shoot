using UnityEngine;
using UnityEngine.Events;

public class PlayerToIslandTeleporter : MonoBehaviour
{
    [SerializeField] private EnemyOnArenaCounter _enemyOnArenaCounter;
    [SerializeField] private Transform _teleportPosition;

    public static event UnityAction PlayerTeleported; 

    private void OnEnable()
    {
        _enemyOnArenaCounter.EnemiesOnArenaDied += OnEnemiesOnArenaDied;
    }

    private void OnDisable()
    {
        _enemyOnArenaCounter.EnemiesOnArenaDied += OnEnemiesOnArenaDied;
    }

    private void OnEnemiesOnArenaDied()
    {
        transform.position = _teleportPosition.position;
        PlayerTeleported?.Invoke();
    }
}

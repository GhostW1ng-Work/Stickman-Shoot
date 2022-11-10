using UnityEngine;

public class CannonSwitcher : MonoBehaviour
{
    [SerializeField] private EnemyOnArenaCounter _enemyOnArenaCounter;
    [SerializeField] private CannonActivator _cannonFirstIsland;
    [SerializeField] private CannonActivator _cannonSecondIsland;

    private void OnEnable()
    {
        _enemyOnArenaCounter.EnemiesOnArenaDied += OnEnemiesOnArenaDied;
    }

    private void OnDisable()
    {
        _enemyOnArenaCounter.EnemiesOnArenaDied -= OnEnemiesOnArenaDied;
    }

    private void OnEnemiesOnArenaDied()
    {
        _cannonFirstIsland.gameObject.SetActive(false);
        _cannonSecondIsland.SetIsActive(true);
    }
}

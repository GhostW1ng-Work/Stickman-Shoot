using UnityEngine;
using UnityEngine.Events;

public class EnemyCounter : MonoBehaviour
{
    [SerializeField] private EnemyOnArenaCounter _enemyOnArenaCounter;

    private int _enemyCount;
    private EnemyChecker[] _enemies;

    public event UnityAction EnemiesPlucked;

    private void Start()
    {
        _enemyCount = 0;
        _enemies = FindObjectsOfType<EnemyChecker>();
    }

    private void Update()
    {
        if (_enemyCount >= _enemies.Length)
            EnemiesPlucked?.Invoke();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out Enemy enemy))
        {
            _enemyCount++;
            enemy.DeactivateParentObject();
            _enemyOnArenaCounter.CheckEnemy(enemy.ParentObject);
        }

        if(other.TryGetComponent(out EnemyIceCube cube))
        {
            _enemyCount++;
            cube.gameObject.SetActive(false);
        }
    }
}

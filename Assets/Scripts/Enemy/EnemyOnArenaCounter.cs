using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyOnArenaCounter : MonoBehaviour
{
    [SerializeField] private List<EnemyChecker> _enemiesOnArena;

    private int _enemyCount = 0;

    public event UnityAction EnemiesOnArenaDied;

    private void Update()
    {
        if (_enemyCount >= _enemiesOnArena.Count)
        {
            EnemiesOnArenaDied?.Invoke();
        }
    }

    public void CheckEnemy(EnemyChecker enemy)
    {
        if (_enemiesOnArena.Contains(enemy))
        {
            _enemyCount++;  
        }
    }
}

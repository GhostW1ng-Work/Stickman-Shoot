using System.Collections.Generic;
using UnityEngine;

public class EnemyTargetSetter : MonoBehaviour
{
    [SerializeField] private List<Target> _enemies;

    private Target _currentTarget;
    private EnemyAttacker _enemyAttacker;

    public Target CurrentTarget => _currentTarget;

    private void OnEnable()
    {
        _enemyAttacker.WeaponPickedUp += OnWeaponPickedUp;
        Enemy.AnyDied += OnWeaponPickedUp;
    }

    private void OnDisable()
    {
        _enemyAttacker.WeaponPickedUp -= OnWeaponPickedUp;
        Enemy.AnyDied -= OnWeaponPickedUp;
    }

    private void Start()
    {
        int currentTargetIndex = Random.Range(0, _enemies.Count);
        _currentTarget = _enemies[currentTargetIndex];
        _enemyAttacker = GetComponent<EnemyAttacker>();
    }

    private void OnWeaponPickedUp()
    {
        int targetIndex = Random.Range(0, _enemies.Count);
        if(_currentTarget.IsAlive == true)
        {
            return;
        }
        else
        {
            targetIndex = Random.Range(0, _enemies.Count);
        }

        _currentTarget = _enemies[targetIndex];
    }
}

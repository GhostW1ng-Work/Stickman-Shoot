using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VictoryPanelShower : MonoBehaviour
{
    [SerializeField] private EnemyCounter _enemyCounter;
    [SerializeField] private GameObject _victoryPanel;

    private void OnEnable()
    {
        _enemyCounter.EnemiesPlucked += OnEnemiesPlucked;
    }

    private void OnDisable()
    {
        _enemyCounter.EnemiesPlucked -= OnEnemiesPlucked;
    }

    private void OnEnemiesPlucked()
    {
        _victoryPanel.SetActive(true);
    }
}

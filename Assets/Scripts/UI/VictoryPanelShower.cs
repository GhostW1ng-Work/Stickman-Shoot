using UnityEngine;
using UnityEngine.Events;

public class VictoryPanelShower : MonoBehaviour
{
    [SerializeField] private EnemyCounter _enemyCounter;
    [SerializeField] private GameObject _victoryPanel;

    public event UnityAction Winned;

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
        Winned?.Invoke();
        _victoryPanel.SetActive(true);
    }
}

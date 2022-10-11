using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class VictoryPanelShower : MonoBehaviour
{
    [SerializeField] private EnemyCounter _enemyCounter;
    [SerializeField] private GameObject _victoryPanel;
    [SerializeField] private float _waitForActivate;

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
        StartCoroutine(Wait(_waitForActivate));
    }

    private IEnumerator Wait(float waitForActivate)
    {
        yield return new WaitForSeconds(waitForActivate);
        _victoryPanel.SetActive(true);
    }
}

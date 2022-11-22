using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class VictoryPanelShower : MonoBehaviour
{
    [SerializeField] private EnemyCounter _enemyCounter;
    [SerializeField] private PlayerChecker _playerChecker;
    [SerializeField] private VideoAdShower _videoAdShower;
    [SerializeField] private GameObject _victoryPanel;
    [SerializeField] private float _waitForActivate;

    private bool _isGameEnd = false;

    public event UnityAction Winned;

    private void OnEnable()
    {
        Boss.BossDied += OnEnemiesPlucked;
        _enemyCounter.EnemiesPlucked += OnEnemiesPlucked;
        _playerChecker.PlayerFalled += OnPlayerFalled;
        _videoAdShower.VideoShowed += OnVideoShowed;
    }

    private void OnDisable()
    {
        Boss.BossDied -= OnEnemiesPlucked;
        _enemyCounter.EnemiesPlucked -= OnEnemiesPlucked;
        _playerChecker.PlayerFalled -= OnPlayerFalled;
        _videoAdShower.VideoShowed -= OnVideoShowed;
    }

    private void OnEnemiesPlucked()
    {
        if (!_isGameEnd)
        {
            Winned?.Invoke();
            StartCoroutine(Wait(_waitForActivate));
            _isGameEnd = true;
        }
        else
        {
            return;
        }
    }

    private void OnPlayerFalled()
    {
        _isGameEnd = true;
    }

    private void OnVideoShowed()
    {
        _isGameEnd = false;
    }

    private IEnumerator Wait(float waitForActivate)
    {
        yield return new WaitForSeconds(waitForActivate);
        _victoryPanel.SetActive(true);
    }
}

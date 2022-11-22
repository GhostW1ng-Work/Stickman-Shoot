using UnityEngine;

public class DefeatPanelShower : MonoBehaviour
{
    [SerializeField] private PlayerChecker _playerChecker;
    [SerializeField] private VideoAdShower _videoAdShower;
    [SerializeField] private EnemyCounter _enemyCounter;
    [SerializeField] private GameObject _defeatPanel;
    [SerializeField] private GameObject _weaponPanel;

    private bool _isGameEnd = false;

    private void OnEnable()
    {
        _playerChecker.PlayerFalled += OnPlayerFalled;
        _videoAdShower.VideoShowed += OnVideoAdShowed;
        _enemyCounter.EnemiesPlucked += OnEnemiesPlucked;
        Boss.BossDied += OnEnemiesPlucked;

    }

    private void OnDisable()
    {
        _playerChecker.PlayerFalled -= OnPlayerFalled;
        _videoAdShower.VideoShowed -= OnVideoAdShowed;
        _enemyCounter.EnemiesPlucked -= OnEnemiesPlucked;
        Boss.BossDied -= OnEnemiesPlucked;
    }

    private void OnPlayerFalled()
    {
        if (!_isGameEnd)
        {
            _defeatPanel.SetActive(true);
            _weaponPanel.SetActive(false);
            _isGameEnd = true;
        }
        else
        {
            return;
        }
    }

    private void OnVideoAdShowed()
    {
        _defeatPanel.SetActive(false);
        _isGameEnd = false;
    }

    private void OnEnemiesPlucked()
    {
        _isGameEnd = true;
    }
}

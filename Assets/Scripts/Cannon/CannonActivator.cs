using UnityEngine;

public class CannonActivator : MonoBehaviour
{
    [SerializeField] private PlayerChecker _playerChecker;
    [SerializeField] private VideoAdShower _videoAdShower;
    [SerializeField] private MoveToStartPanelDisabler _moveToStartPanelDisabler;
    [SerializeField] private Timer _timer;
    [SerializeField] private EnemyCounter _enemyCounter;
    [SerializeField] private float _timeToActivate;
    [SerializeField] private GameObject[] _cannons;
    [SerializeField] private bool _isActive = true;


    private int _cannonIndex;

    private void OnEnable()
    {
        Boss.BossDied += DeactivateCannonContainer;
        _enemyCounter.EnemiesPlucked += DeactivateCannonContainer;
        _playerChecker.PlayerFalled += DeactivateCannonContainer;
        _moveToStartPanelDisabler.AnyKeyPressed += ActivateCannonContainer;
        _videoAdShower.VideoShowed += ActivateCannonContainer;
    }

    private void OnDisable()
    {
        Boss.BossDied -= DeactivateCannonContainer;
        _enemyCounter.EnemiesPlucked -= DeactivateCannonContainer;
        _playerChecker.PlayerFalled -= DeactivateCannonContainer;
        _moveToStartPanelDisabler.AnyKeyPressed -= ActivateCannonContainer;
        _videoAdShower.VideoShowed -= ActivateCannonContainer;
    }

    private void Start()
    {
        _moveToStartPanelDisabler.AnyKeyPressed += ActivateCannonContainer;
        _videoAdShower.VideoShowed += ActivateCannonContainer;
        DeactivateCannonContainer();

        if (_isActive)
        {
            _cannonIndex = Random.Range(0, _cannons.Length);
            _cannons[_cannonIndex].gameObject.SetActive(true);
        }

    }

    private void Update()
    {
        if (_isActive)
        {
            _cannonIndex = Random.Range(0, _cannons.Length);
            if (_timer.ElapsedTime >= _timeToActivate)
            {
                _cannons[_cannonIndex].gameObject.SetActive(true);
                _timer.ResetTimer();
            }
        }
    }

    private void ActivateCannonContainer()
    {
        gameObject.SetActive(true);
    }

    private void DeactivateCannonContainer()
    {
        gameObject.SetActive(false);
    }

    public void SetIsActive(bool isActive)
    {
        _isActive = isActive;
    }
}

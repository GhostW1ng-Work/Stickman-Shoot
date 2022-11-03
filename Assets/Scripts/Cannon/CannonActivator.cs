using UnityEngine;

public class CannonActivator : MonoBehaviour
{
    [SerializeField] private PlayerChecker _playerChecker;
    [SerializeField] private Timer _timer;
    [SerializeField] private EnemyCounter _enemyCounter;
    [SerializeField] private float _timeToActivate;
    [SerializeField] private GameObject[] _cannons;

    private int _cannonIndex;

    private void OnEnable()
    {
        _enemyCounter.EnemiesPlucked += DeactivateCannonContainer;
        _playerChecker.PlayerFalled += DeactivateCannonContainer;
    }

    private void OnDisable()
    {
        _enemyCounter.EnemiesPlucked -= DeactivateCannonContainer;
        _playerChecker.PlayerFalled -= DeactivateCannonContainer;
    }

    private void Start()
    {
        _cannonIndex = Random.Range(0, _cannons.Length);
        _cannons[_cannonIndex].gameObject.SetActive(true);
    }

    private void Update()
    {
        _cannonIndex = Random.Range(0, _cannons.Length);
        if (_timer.ElapsedTime >= _timeToActivate)
        {
            _cannons[_cannonIndex].gameObject.SetActive(true);
            _timer.ResetTimer();
        }
    }

    private void DeactivateCannonContainer()
    {
        gameObject.SetActive(false);
    }
}

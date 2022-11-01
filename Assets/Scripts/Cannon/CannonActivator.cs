using UnityEngine;

public class CannonActivator : MonoBehaviour
{
    [SerializeField] private Timer _timer;
    [SerializeField] private EnemyCounter _enemyCounter;
    [SerializeField] private float _timeToActivate;
    [SerializeField] private GameObject[] _cannons;

    private int _cannonIndex;

    private void OnEnable()
    {
        _enemyCounter.EnemiesPlucked += OnEnemiesPlucked;
    }

    private void OnDisable()
    {
        _enemyCounter.EnemiesPlucked -= OnEnemiesPlucked;
    }

    private void Start()
    {
    }

    private void Update()
    {
        if(_cannonIndex < _cannons.Length)
        {
            if (_timer.ElapsedTime >= _timeToActivate)
            {
                _cannons[_cannonIndex].gameObject.SetActive(true);
                _cannonIndex++;
                _timer.ResetTimer();
            }
        }
        else
        {
            _cannonIndex = 0;
        }
    }

    private void OnEnemiesPlucked()
    {
        gameObject.SetActive(false);
    }
}

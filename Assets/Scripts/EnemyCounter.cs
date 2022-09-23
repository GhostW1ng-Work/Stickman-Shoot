using UnityEngine;
using UnityEngine.Events;

public class EnemyCounter : MonoBehaviour
{
    private int _enemyCount;

    public event UnityAction EnemiesPlucked;

    private void Start()
    {
        _enemyCount = 0;  
    }

    private void Update()
    {
        if (_enemyCount >= 3)
            EnemiesPlucked?.Invoke();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out Enemy enemy))
        {
            _enemyCount++;
            enemy.gameObject.SetActive(false);
        }
    }
}

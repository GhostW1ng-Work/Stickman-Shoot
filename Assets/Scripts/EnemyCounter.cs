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
            Debug.Log("Враг упал");
            _enemyCount++;
            enemy.DeactivateParentObject();
        }

        if(other.TryGetComponent(out EnemyIceCube cube))
        {
            _enemyCount++;
            cube.gameObject.SetActive(false);
        }
    }
}

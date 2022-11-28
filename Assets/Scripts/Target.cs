using UnityEngine;
using UnityEngine.Events;

public class  Target : MonoBehaviour
{
    [SerializeField] private Enemy _enemy;

    private bool _isAlive = true;

    public bool IsAlive => _isAlive;

    private void OnEnable()
    {
        _enemy.Died += OnDied;
    }

    private void OnDisable()
    {
        
    }

    private void OnDied()
    {
        _isAlive = false;
    }
}

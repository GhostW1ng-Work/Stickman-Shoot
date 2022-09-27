using UnityEngine;

public class EnemyPointersHandler : MonoBehaviour
{
    [SerializeField] private PlayerGunner _gunner;

    private bool _pointerIsActive;

    public bool PointerIsActive => _pointerIsActive;

    private void Update() { }

    private void OnEnable()
    {
        _gunner.EnemyHitted += OnEnemyHitted;
        _gunner.EnemyMissed += OnEnemyMissed;
    }

    private void OnDisable()
    {
        _gunner.EnemyHitted -= OnEnemyHitted;
        _gunner.EnemyMissed -= OnEnemyMissed;
    }

    private void OnEnemyHitted()
    {
        _pointerIsActive = true;
    }

    private void OnEnemyMissed()
    {
        _pointerIsActive = false;
    }
}

using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private PlayerGunner _gunner;
    [SerializeField] private GameObject _pointer;
    [SerializeField] private EnemyPointersHandler _pointersHandler;

    private EnemyMover _mover;
    private Rigidbody _rigidbody;

    private void OnEnable()
    {
        _gunner.EnemyMissed += OnEnemyMissed;
    }

    private void OnDisable()
    {
        _gunner.EnemyMissed -= OnEnemyMissed;
    }

    private void Start()
    {
        _mover = GetComponent<EnemyMover>();
        _rigidbody = GetComponent<Rigidbody>();
    }

    public void ActivatePointer()
    {
        if (_pointersHandler.PointerIsActive == false)
            _pointer.SetActive(true);
    }

    private void OnEnemyMissed()
    {
        _pointer.SetActive(false);
    }
    public void PushEnemy(Transform playerPosition, float pushPower)
    {
        _mover.SetIsRunning();
        var currentDirection = transform.position - playerPosition.position;
        _rigidbody.AddForce(currentDirection * pushPower, ForceMode.Impulse);
    }

    public void Freeze(IceCube iceCube)
    {
        iceCube.transform.SetParent(transform);
        iceCube.transform.localPosition = new Vector3(0, 1, 0);
    }
}

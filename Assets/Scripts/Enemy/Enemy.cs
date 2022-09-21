using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private PlayerGunner _gunner;
    [SerializeField] private GameObject _pointer;
    [SerializeField] private EnemyPointersHandler _pointersHandler;
    [SerializeField] private EnemyIceCube _iceCube;

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

    private void Update()
    {
        _iceCube.transform.localPosition = new Vector3(0, 1, 0);
    }

    private void OnEnemyMissed()
    {
        _pointer.SetActive(false);
    }

    public void ActivatePointer()
    {
        if (_pointersHandler.PointerIsActive == false)
            _pointer.SetActive(true);
    }

    public void PushEnemy(Transform playerPosition, float pushPower)
    {
        _mover.SetIsRunning();
        var currentDirection = transform.position - playerPosition.position;
        _rigidbody.AddForce(currentDirection * pushPower, ForceMode.Impulse);
    }

    public void Freeze()
    {
        _mover.SetIsRunning();
        _iceCube.gameObject.SetActive(true);
    }
}

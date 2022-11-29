using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private EnemyCounter _enemyCounter;
    [SerializeField] private FloatingJoystick _joystick;
    [SerializeField] private AudioSource _winSound;
    [SerializeField] private GameObject _playerIceCube;
    [SerializeField] private float _timeToAntiFreeze;

    private BoxCollider _collider;
    private Animator _animator;
    private PlayerAttacker _attacker;
    private Rigidbody _rigidBody;
    private bool _isWin = false;

    public event UnityAction Freezed;
    public event UnityAction AntiFreezed;

    private void Start()
    {
        _collider = GetComponent<BoxCollider>();
        _animator = GetComponent<Animator>();
        _attacker = GetComponent<PlayerAttacker>();
        _rigidBody = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        _enemyCounter.EnemiesPlucked += OnEnemiesPlucked;
        Boss.BossDied += OnEnemiesPlucked;
    }

    private void OnDisable()
    {
        _enemyCounter.EnemiesPlucked -= OnEnemiesPlucked;
        Boss.BossDied -= OnEnemiesPlucked;
    }

    private void OnEnemiesPlucked()
    {
        if (!_isWin)
        {
            _isWin = true;
            _winSound.PlayOneShot(_winSound.clip);
            _joystick.gameObject.SetActive(false);
            _animator.SetBool("Dance", true);
            _attacker.enabled = false;
        }
    }

    private IEnumerator WaitToAntifreeze()
    {
        yield return new WaitForSeconds(_timeToAntiFreeze);
        AntiFreezed?.Invoke();
        transform.parent = null;
        _playerIceCube.SetActive(false);
        _collider.isTrigger = false;
        _rigidBody.isKinematic = false;
    }

    public void PushPlayer(Transform pusherPosition, float pushPower)
    {
        Vector3 currentDirection = (transform.position - pusherPosition.position).normalized;
        _rigidBody.AddForce(currentDirection  * pushPower, ForceMode.Impulse);
    }

    public void Freeze()
    {
        _rigidBody.isKinematic = true;
        _collider.isTrigger = true;
        _playerIceCube.SetActive(true);
        _playerIceCube.transform.position = new Vector3(transform.position.x,1,transform.position.z);
        transform.SetParent(_playerIceCube.transform);
        transform.localPosition = new Vector3(0, -0.4f, 0);
        StartCoroutine(WaitToAntifreeze());
        Freezed?.Invoke();
    }
}

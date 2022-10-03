using System.Collections;
using UnityEngine;

[RequireComponent(typeof(EnemyMover), typeof(Rigidbody))]
public class Enemy : MonoBehaviour
{
    [SerializeField] private EnemyIceCube _iceCube;
    [SerializeField] private ParticleSystem[] _particles;
    [SerializeField] private EnemyRaycastChecker _checker;
    [SerializeField] private float _timeToActivate;
    [SerializeField] private float _timeToDefrost;
    [SerializeField] private Animator _animator;

    private EnemyRagdoll _ragdoll;
    private EnemyMover _mover;
    private Rigidbody _rigidbody;
    private bool _isAttacked;

    public bool IsAttacked => _isAttacked;
    public float TimeToActivate => _timeToActivate;

    private void Start()
    {
        _ragdoll = GetComponent<EnemyRagdoll>();
        _mover = GetComponent<EnemyMover>();
        _rigidbody = GetComponent<Rigidbody>();
        _isAttacked = false;
    }

    private void Update()
    {
        _iceCube.transform.localPosition = new Vector3(0, 1, 0);
    }

    private IEnumerator ActivateTimeToRise()
    {
        yield return new WaitForSeconds(_timeToActivate);

        foreach (var particle in _particles)
        {
            particle.gameObject.SetActive(false);
        }

        _isAttacked = false;
        _mover.SetIsRunningTrue();
    }

    private IEnumerator ActivateTimeToDefrost()
    {
        yield return new WaitForSeconds(_timeToDefrost);
        _isAttacked = false;
        _iceCube.gameObject.SetActive(false);
        _mover.SetIsRunningTrue();
    }

    public void PushEnemy(Transform playerPosition, float pushPower)
    {
        foreach (var particle in _particles)
        {
            particle.gameObject.SetActive(true);
        }

        _isAttacked = true;
        _ragdoll.PushEnemy(playerPosition, pushPower);
        _mover.SetIsRunningFalse();
        StartCoroutine(ActivateTimeToRise());
    }

    public void Freeze()
    {
        _checker.DeactivatePointer();
        _isAttacked = true;
        _mover.SetIsRunningFalse();
        _iceCube.gameObject.SetActive(true);
        transform.localRotation = Quaternion.Euler(0, 0, 0);
        StartCoroutine(ActivateTimeToDefrost());
    }
}

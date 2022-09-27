using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private EnemyIceCube _iceCube;
    [SerializeField] private ParticleSystem[] _particles;

    private EnemyMover _mover;
    private Rigidbody _rigidbody;
    private Animator _animator;
    private bool _isAttacked;

    public bool IsAttacked => _isAttacked;

    private void Start()
    {
        _mover = GetComponent<EnemyMover>();
        _rigidbody = GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();
        _isAttacked = false;
    }

    private void Update()
    {
        _iceCube.transform.localPosition = new Vector3(0, 1, 0);
    }

    private IEnumerator ActivateTimeToRise()
    {
        yield return new WaitForSeconds(5f);

        foreach (var particle in _particles)
        {
            particle.gameObject.SetActive(false);
        }

        _isAttacked = false;
        _animator.SetBool("isFalling", false);
        _mover.SetIsRunningTrue();
    }

    public void PushEnemy(Transform playerPosition, float pushPower)
    {
        foreach (var particle in _particles)
        {
            particle.gameObject.SetActive(true);
        }

        _isAttacked = true;
        _animator.SetBool("isFalling", true);
        _mover.SetIsRunningFalse();
        var currentDirection = transform.position - playerPosition.position;
        _rigidbody.AddForce(currentDirection * pushPower, ForceMode.Impulse);
        StartCoroutine(ActivateTimeToRise());
    }

    public void Freeze()
    {
        _isAttacked = true;
        _mover.SetIsRunningFalse();
        _iceCube.gameObject.SetActive(true);
        transform.localRotation = Quaternion.Euler(0, 0, 0);
    }
}

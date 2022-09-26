using System.Collections;
using UnityEngine;
using DG.Tweening;

public class Enemy : MonoBehaviour
{
    [SerializeField] private EnemyIceCube _iceCube;
    [SerializeField] private ParticleSystem[] _particles;

    private EnemyMover _mover;
    private Rigidbody _rigidbody;
    private Animator _animator;

    private void Start()
    {
        _mover = GetComponent<EnemyMover>();
        _rigidbody = GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();
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

        _animator.SetBool("isFalling", false);
        _mover.SetIsRunning();
    }

    public void PushEnemy(Transform playerPosition, float pushPower)
    {
        foreach (var particle in _particles)
        {
            particle.gameObject.SetActive(true);
        }

        _animator.SetBool("isFalling", true);
        _mover.SetIsRunning();
        var currentDirection = transform.position - playerPosition.position;
        _rigidbody.AddForce(currentDirection * pushPower, ForceMode.Impulse);
        StartCoroutine(ActivateTimeToRise());
    }

    public void Freeze()
    {
        _mover.SetIsRunning();
        _iceCube.gameObject.SetActive(true);
        transform.localRotation = Quaternion.Euler(0, 0, 0);
    }
}

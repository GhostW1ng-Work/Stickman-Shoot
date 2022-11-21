using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class ProjectileSpawner : MonoBehaviour
{
    [SerializeField] private Projectile _projectilePrefab;
    [SerializeField] private Player _target;
    [SerializeField] private AudioSource _shootSound;
    [SerializeField] private Transform _spawnZone;
    [SerializeField] private Transform _direction;
    [SerializeField] private float _timeForIncrease;
    [SerializeField] private float _timeToDecrease;
    [SerializeField] private float _timeForDecrease;

    private bool _isSpawned = false;

    public bool IsSpawned => _isSpawned;

    public event UnityAction AnimationEnded;

    private IEnumerator Shoot(Animator animator)
    {
        _isSpawned = false;
        animator.SetTrigger("isIncreased");
        yield return new WaitForSeconds(_timeForIncrease);

        if (_isSpawned == false)
        {
            var spawned = Instantiate(_projectilePrefab, _spawnZone.position, Quaternion.Euler(0,0,0));
            _shootSound.Play();
            spawned.SetDirection(_direction.position);
            spawned.SetTarget(_target);

            _isSpawned = true;
        }
    }

    private IEnumerator Wait(Animator animator)
    {
        yield return new WaitForSeconds(_timeToDecrease);
        animator.SetTrigger("isDecreased");
        yield return new WaitForSeconds(_timeForDecrease);
        AnimationEnded?.Invoke();
    }

    public void ActivateCoroutineWait(Animator animator)
    {
        StartCoroutine(Wait(animator));
    }

    public void ActivateCoroutineShoot(Animator animator)
    {
        StartCoroutine(Shoot(animator));
    }
}

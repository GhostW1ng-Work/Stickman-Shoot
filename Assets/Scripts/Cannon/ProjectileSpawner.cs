using System.Collections;
using UnityEngine;

public class ProjectileSpawner : MonoBehaviour
{
    [SerializeField] private Projectile _projectilePrefab;
    [SerializeField] private Transform _spawnZone;
    [SerializeField] private Transform _direction;
    [SerializeField] private float _timeForIncrease;
    [SerializeField] private float _timeToDecrease;
    [SerializeField] private float _timeForDecrease;

    private bool _isSpawned = false;

    public bool IsSpawned => _isSpawned;

    private IEnumerator Shoot(Animator animator)
    {
        _isSpawned = false;
        animator.SetTrigger("isIncreased");
        yield return new WaitForSeconds(_timeForIncrease);

        if (_isSpawned == false)
        {
            var spawned = Instantiate(_projectilePrefab, _spawnZone.position, Quaternion.Euler(0,0,0));
            spawned.SetDirection(_direction.position);
            _isSpawned = true;
        }
    }

    private IEnumerator Wait(Animator animator, GameObject cannon)
    {
        yield return new WaitForSeconds(_timeToDecrease);
        animator.SetTrigger("isDecreased");
        yield return new WaitForSeconds(_timeForDecrease);
        cannon.SetActive(false);
    }

    public void ActivateCoroutineWait(Animator animator, GameObject cannon)
    {
        StartCoroutine(Wait(animator, cannon));
    }

    public void ActivateCoroutineShoot(Animator animator)
    {
        StartCoroutine(Shoot(animator));
    }
}

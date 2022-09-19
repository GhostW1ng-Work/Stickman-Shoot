using System.Collections;
using UnityEngine;

public class ProjectileSpawner : MonoBehaviour
{
    [SerializeField] private Projectile _projectilePrefab;
    [SerializeField] private Transform _spawnZone;
    [SerializeField] private Transform _direction;

    private bool _isSpawned = false;

    public bool IsSpawned => _isSpawned;

    private IEnumerator Shoot(Animator animator)
    {
        _isSpawned = false;
        animator.SetTrigger("isIncreased");
        yield return new WaitForSeconds(1f);

        if (_isSpawned == false)
        {
            var spawned = Instantiate(_projectilePrefab, _spawnZone.position, Quaternion.Euler(0,0,0));
            spawned.SetDirection(_direction.position);
            _isSpawned = true;
        }
    }

    private IEnumerator Wait(Animator animator, GameObject cannon)
    {
        yield return new WaitForSeconds(3);
        animator.SetTrigger("isDecreased");
        yield return new WaitForSeconds(0.3f);
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

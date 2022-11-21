using System.Collections;
using UnityEngine;

public class EnemyRagdoll : MonoBehaviour
{
    [SerializeField] private Rigidbody[] _limbs;
    [SerializeField] private Animator _animator;
    [SerializeField] private Transform _parentTransform;

    private Enemy _enemy;

    public Rigidbody[] Limbs => _limbs;

    private void Start()
    {
        _enemy = GetComponent<Enemy>();
        DeactivateRagdoll();
    }

    public void ActivateRagdoll()
    {
        _animator.enabled = false;

        for (int i = 0; i < _limbs.Length; i++)
        {
            _limbs[i].isKinematic = false;
        }
    }

    public void DeactivateRagdoll()
    {
        _animator.enabled = true;

        for (int i = 0; i < _limbs.Length; i++)
        {
            _limbs[i].isKinematic = true;
        }
    }

    public void PushEnemy(Transform pusherPosition, float pushPower)
    {
        var currentDirection = transform.position - pusherPosition.position;
        ActivateRagdoll();

        for (int i = 0; i < _limbs.Length; i++)
        {
            _limbs[i].AddForce(currentDirection * pushPower, ForceMode.Impulse);
        }
        StartCoroutine(WaitUntilFall(_enemy.TimeToActivate));
    }

    private IEnumerator WaitUntilFall(float timeToActivate)
    {
        yield return new WaitForSeconds(timeToActivate);

        _parentTransform.position = new Vector3(transform.position.x, 0, transform.position.z);

        foreach (var limb in _limbs)
        {
            limb.transform.localPosition = Vector3.zero;
        }
        DeactivateRagdoll();
    }
}   

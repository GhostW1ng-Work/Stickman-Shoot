using System.Collections;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(EnemyMover), typeof(Rigidbody))]
public class Enemy : MonoBehaviour
{
    [SerializeField] private EnemyIceCube _iceCube;
    [SerializeField] private ParticleSystem[] _particles;
    [SerializeField] private float _timeToActivate;
    [SerializeField] private EnemyChecker _parentObject;

    private EnemyRagdoll _ragdoll;
    private EnemyMover _mover;
    private bool _isAttacked;

    public bool IsAttacked => _isAttacked;
    public float TimeToActivate => _timeToActivate;
    public EnemyChecker ParentObject => _parentObject;

    public event UnityAction Freezed;
    public event UnityAction Died;
    public static event UnityAction AnyDied;

    private void Start()
    {
        _ragdoll = GetComponent<EnemyRagdoll>();
        _mover = GetComponent<EnemyMover>();
        _isAttacked = false;
    }

    private void Update()
    {
        _iceCube.transform.localPosition = new Vector3(0, 1, 0);
    }

    private IEnumerator ActivateTimeToRise(float timeToActivate)
    {
        yield return new WaitForSeconds(timeToActivate);

        foreach (var particle in _particles)
        {
            particle.gameObject.SetActive(false);
        }

        _isAttacked = false;
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
        StartCoroutine(ActivateTimeToRise(_timeToActivate));
    }

    public void Freeze()
    {
        Freezed?.Invoke();
        _iceCube.gameObject.SetActive(true);
        _iceCube.transform.position = transform.position;
        _parentObject.gameObject.SetActive(false);
    }

    public void DeactivateParentObject()
    {
        Died?.Invoke();
        AnyDied?.Invoke();
        _parentObject.gameObject.SetActive(false);
    }
}

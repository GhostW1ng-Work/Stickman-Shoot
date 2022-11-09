using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class PlayerToIslandMover : MonoBehaviour
{
    [SerializeField] private EnemyOnArenaCounter _enemyOnArenaCounter;
    [SerializeField] private Transform _targetPosition;
    [SerializeField] private float _timeForMoving;

    private NavMeshAgent _navMeshAgent;
    private DesktopMover _desktopMover;
    private MobileMover _mobileMover;

    private void OnEnable()
    {
        _enemyOnArenaCounter.EnemiesOnArenaDied += OnEnemiesOnArenaDied;
    }

    private void OnDisable()
    {
        _enemyOnArenaCounter.EnemiesOnArenaDied += OnEnemiesOnArenaDied;
    }

    private void Start()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _desktopMover = GetComponent<DesktopMover>();
        _mobileMover = GetComponent<MobileMover>();
    }

    private void Update()
    {
        Debug.Log(Vector3.Distance(transform.position, _targetPosition.position));
    }

    private void OnEnemiesOnArenaDied()
    {
        StartCoroutine(WaitForMoving());  
    }

    private IEnumerator WaitForMoving()
    {
        _desktopMover.enabled = false;
        _mobileMover.enabled = false;
        _navMeshAgent.enabled = true;
        _navMeshAgent.SetDestination(_targetPosition.position);

        yield return new WaitForSeconds(_timeForMoving);

        _navMeshAgent.isStopped = true;
        _navMeshAgent.enabled = false;
        _desktopMover.enabled = true;
    }
}

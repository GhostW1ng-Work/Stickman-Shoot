using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class BossMover : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private float _pushPower;

    private bool _attackPlayer;
    private NavMeshAgent _agent;

    private void Start()
    {
        _agent = GetComponent<NavMeshAgent>();

    }

    private void Update()
    {
        _agent.SetDestination(_player.transform.position);

        if(_agent.remainingDistance < _agent.stoppingDistance)
        {
            StartCoroutine(Attack());
        }
        else
        {
            _agent.isStopped = false;
            StopCoroutine(Attack());
        }
    }

    private IEnumerator Attack()
    {
        _attackPlayer = false;
        _agent.isStopped = true;
        yield return new WaitForSeconds(5f);

        if (!_attackPlayer)
        {
            _player.PushPlayer(transform, _pushPower);
            _attackPlayer = true;
        }   
    }
}

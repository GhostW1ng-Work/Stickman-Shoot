using UnityEngine;
using UnityEngine.AI;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] private Transform[] _points;
    [SerializeField] private float _distanceToChangeGoal;

    private NavMeshAgent _agent;
    private Animator _animator;
    private int _currentPointIndex;
    private int _index;
    private bool _isRunning;

    private void Start()
    {
        _isRunning = true;
        _index = Random.Range(0, _points.Length);
        _currentPointIndex = _index;
        _agent = GetComponent<NavMeshAgent>();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        _agent.enabled = true;

        if (_isRunning == true)
        {
            if (_agent.remainingDistance < _distanceToChangeGoal)
            {
                _index = Random.Range(0, _points.Length);
                _currentPointIndex = _index;

                _agent.SetDestination(_points[_currentPointIndex].position);
                Rotate();
                _animator.SetBool("isRunning", true);
            }
        }
        else
        {
            _agent.isStopped = true;
            _agent.enabled = false;
        }
    }

    private Vector3 Rotate()
    {
        Quaternion desiredRot = Quaternion.FromToRotation(_agent.velocity, _agent.desiredVelocity);
        float maxYAngleThisFrame = _agent.angularSpeed * Time.deltaTime;
        float desiredYAngle = desiredRot.eulerAngles.y;
        if (desiredYAngle > 180) desiredYAngle -= 360;
        if (Mathf.Abs(desiredYAngle) > maxYAngleThisFrame)
        {
            desiredRot.eulerAngles = new Vector3(desiredRot.eulerAngles.x, Mathf.Sign(desiredYAngle) * maxYAngleThisFrame, desiredRot.eulerAngles.z);
        }
        return desiredRot * _agent.velocity;
    }

    public void SetIsRunningTrue()
    {
        _isRunning = true;
        _animator.SetBool("isRunning", _isRunning);
    }

    public void SetIsRunningFalse()
    {
        _isRunning = false;
        _animator.SetBool("isRunning", _isRunning);
    }
}

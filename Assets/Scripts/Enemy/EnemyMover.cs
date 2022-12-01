using UnityEngine;
using UnityEngine.AI;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] private Transform[] _points;
    [SerializeField] private float _distanceToChangeGoal;
    [SerializeField] private NavMeshAgent _agent;
    [SerializeField] private Animator _animator;
    [SerializeField] private MoveToStartPanelDisabler _moveToStartPanelDisabler;
    [SerializeField] private EnemyAttacker _enemyAttacker;
    [SerializeField] private EnemyTargetSetter _targetSetter;

    private int _currentPointIndex;
    private int _index;
    private bool _isRunning;
    private bool _withWeapon = false;
    private float _baseSpeed = 3.5f;

    private void OnEnable()
    {
        Agava.WebUtility.WebApplication.InBackgroundChangeEvent += OnInBackgroundChange;
        _moveToStartPanelDisabler.AnyKeyPressed += OnAnyKeyPressed;
        _enemyAttacker.WeaponPickedUp += OnWeaponPickedUp;
        _enemyAttacker.Attacked += OnAttacked;
    }

    private void OnDisable()
    {
        Agava.WebUtility.WebApplication.InBackgroundChangeEvent -= OnInBackgroundChange;
        _moveToStartPanelDisabler.AnyKeyPressed -= OnAnyKeyPressed;
        _enemyAttacker.WeaponPickedUp -= OnWeaponPickedUp;
        _enemyAttacker.Attacked -= OnAttacked;
    }

    private void Start()
    {
        _isRunning = false;
        _index = Random.Range(0, _points.Length);
        _currentPointIndex = _index;
    }

    private void Update()
    {
    
        if(_points.Length != 0)
        {
            
            if (_isRunning == true)
            {
                _agent.enabled = true;
                if (_withWeapon)
                {
                    _agent.speed = 5f;
                    _agent.SetDestination(_targetSetter.CurrentTarget.transform.position);
                }
                else
                {
                    _agent.speed = _baseSpeed;
                    if (_agent.remainingDistance < _distanceToChangeGoal)
                    {
                        _index = Random.Range(0, _points.Length);
                        _currentPointIndex = _index;

                        _agent.SetDestination(_points[_currentPointIndex].position);
                        Rotate();
                        _animator.SetBool("isRunning", true);
                    }
                }
            }
            else
            {
                _agent.isStopped = true;
                _agent.enabled = false;
            }
        }
        else
        {
            _agent.isStopped = true;
            _agent.enabled = false;
            _isRunning = false;
        }  
    }

    private void OnInBackgroundChange(bool inBackground)
    {
        _isRunning = !inBackground;
    }

    private void OnWeaponPickedUp()
    {
        _withWeapon = true;
    }

    private void OnAttacked()
    {
        _withWeapon = false;
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

    private void OnAnyKeyPressed()
    {
        _isRunning = true;
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

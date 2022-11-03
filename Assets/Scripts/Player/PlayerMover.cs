using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody), typeof(BoxCollider), typeof(Animator))]
public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private FloatingJoystick _joystick;
    [SerializeField] private VictoryPanelShower _victoryPanelShower;

    private Rigidbody _rigidbody;
    private Animator _animator;

    private void OnEnable()
    {
        _victoryPanelShower.Winned += OnWinned;
    }

    private void OnDisable()
    {
        _victoryPanelShower.Winned -= OnWinned;
    }

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {

        MovementLogic();
    }

    private void OnWinned()
    {
        _moveSpeed = 0;
    }

    private void MovementLogic()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");

        float moveVertical = Input.GetAxis("Vertical");

        if (Input.GetMouseButton(0))
        {
            _rigidbody.velocity = new Vector3(_joystick.Horizontal * _moveSpeed, 0, _joystick.Vertical * _moveSpeed);
        }
        else
        {
            _rigidbody.velocity = new Vector3(moveHorizontal * _moveSpeed, _rigidbody.velocity.y, moveVertical * _moveSpeed);
        }
     
        if (_joystick.Horizontal != 0 || _joystick.Vertical != 0 || moveHorizontal != 0 || moveVertical != 0 )
        {
            transform.rotation = Quaternion.LookRotation(_rigidbody.velocity);
            _animator.SetBool("isRunning", true);
        }
        else
        {
            _animator.SetBool("isRunning", false);
        }
    }

}

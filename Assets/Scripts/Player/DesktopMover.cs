using UnityEngine;

public class DesktopMover : MonoBehaviour
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

        if (moveHorizontal != 0 || moveVertical != 0)
        {    
            transform.rotation = Quaternion.LookRotation(_rigidbody.velocity);
            _animator.SetBool("isRunning", true);
        }
        else
        {
            _animator.SetBool("isRunning", false);
        }

        _rigidbody.velocity = new Vector3(moveHorizontal * _moveSpeed, _rigidbody.velocity.y, moveVertical * _moveSpeed);
    }
}

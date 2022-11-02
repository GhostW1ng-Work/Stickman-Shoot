using UnityEngine;

public class PlayerFaller : MonoBehaviour
{
    [SerializeField] private GameObject _joystick;

    private Rigidbody _rigidBody;
    private PlayerMover _playerMover;
    private Animator _animator;

    private void Start()
    {
        _rigidBody = GetComponent<Rigidbody>();
        _playerMover = GetComponent<PlayerMover>();
        _animator = GetComponent<Animator>();
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.transform.TryGetComponent(out Ground ground))
        {
            _rigidBody.constraints = RigidbodyConstraints.None;
            _playerMover.enabled = false;
            _joystick.SetActive(false);
            _animator.SetBool("IsFall", true);
        }
    }
}

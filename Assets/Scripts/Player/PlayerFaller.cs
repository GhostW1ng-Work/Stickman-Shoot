using UnityEngine;

public class PlayerFaller : MonoBehaviour
{
    [SerializeField] private GameObject _joystick;
    [SerializeField] private VideoAdShower _videoAdShower;

    private Rigidbody _rigidBody;
    private PlayerMover _playerMover;
    private Animator _animator;

    private void OnEnable()
    {
        _videoAdShower.VideoShowed += OnVideoShowed;
    }

    private void OnDisable()
    {
        _videoAdShower.VideoShowed -= OnVideoShowed;
    }

    private void Start()
    {
        _videoAdShower.VideoShowed += OnVideoShowed;
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

    private void OnVideoShowed()
    {
        _rigidBody.constraints = RigidbodyConstraints.FreezeRotation | RigidbodyConstraints.FreezePositionY;
        _playerMover.enabled = true;
        _animator.SetBool("IsFall", false);
    }
}

using UnityEngine;
using UnityEngine.Events;

public class PlayerFaller : MonoBehaviour
{
    [SerializeField] private VideoAdShower _videoAdShower;

    private Rigidbody _rigidBody;

    public event UnityAction PlayerFalled;

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
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.TryGetComponent(out Ground ground))
        {
            transform.rotation = new Quaternion(0, 0, 0, 0);
            _rigidBody.constraints = RigidbodyConstraints.FreezeRotation | RigidbodyConstraints.FreezePositionY;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.transform.TryGetComponent(out Ground ground))
        {
            PlayerFalled?.Invoke();
            _rigidBody.constraints = RigidbodyConstraints.None;
        }
    }

    private void OnVideoShowed()
    {
        transform.rotation = new Quaternion(0, 0, 0, 0);
        _rigidBody.constraints = RigidbodyConstraints.FreezeRotation | RigidbodyConstraints.FreezePositionY;
    }
}

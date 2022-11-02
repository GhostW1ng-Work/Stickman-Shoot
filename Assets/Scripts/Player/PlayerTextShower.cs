using UnityEngine;

public class PlayerTextShower : MonoBehaviour
{
    [SerializeField] private Player _target;
    [SerializeField] private PlayerChecker _playerChecker;
    [SerializeField] private Vector3 _offset;
    [SerializeField] private float _speed;

    private void OnEnable()
    {
        _playerChecker.PlayerFalled += OnPlayerFalled;
    }

    private void OnDisable()
    {
        _playerChecker.PlayerFalled -= OnPlayerFalled;
    }

    private void Start()
    {
        transform.position = _target.transform.position + _offset;
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, _target.transform.position + _offset, _speed * Time.deltaTime);
    }

    private void OnPlayerFalled()
    {
        gameObject.SetActive(false);
    }
}
 


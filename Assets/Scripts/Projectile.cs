using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private Vector3 _direction;
    [SerializeField] private float _speed;

    private void Update()
    {
        transform.position += transform.forward * _speed * Time.deltaTime;
    }

    public void SetDirection(Vector3 direction)
    {
        transform.LookAt(direction);
    }
}

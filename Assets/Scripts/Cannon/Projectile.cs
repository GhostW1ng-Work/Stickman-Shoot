using UnityEngine;

public abstract class Projectile : MonoBehaviour
{
    [SerializeField] protected float _speed;

    public float Speed => _speed;

    protected abstract void Shoot();
   
    public void SetDirection(Vector3 direction)
    {
        transform.LookAt(direction);
    }
}

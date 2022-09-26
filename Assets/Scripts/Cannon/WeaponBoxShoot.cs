using DG.Tweening;
using UnityEngine;

public class WeaponBoxShoot : Projectile
{
    [SerializeField] private Transform _direction;

    private void OnEnable()
    {
        Shoot();
    }

    protected override void Shoot()
    {
        transform.DOLocalMove(_direction.position, _speed);
    }
}

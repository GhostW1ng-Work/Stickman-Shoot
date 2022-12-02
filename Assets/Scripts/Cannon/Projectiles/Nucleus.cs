using UnityEngine;

public class Nucleus : Projectile
{
    [SerializeField] private float _pushPower;

    private void Update()
    {
        Shoot();
    }

    protected override void Shoot()
    {
        transform.position += transform.forward * _speed * Time.deltaTime;
    }
}

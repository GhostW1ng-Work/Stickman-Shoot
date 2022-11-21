using UnityEngine;

public class Nucleus : Projectile
{
    private void Update()
    {
        Shoot();
    }

    protected override void Shoot()
    {
        transform.position += transform.forward * _speed * Time.deltaTime;
    }
}

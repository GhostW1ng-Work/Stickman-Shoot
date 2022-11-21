using UnityEngine;
using UnityEngine.Events;

public class HomingBomb : Projectile
{
    [SerializeField] private float _pushPower;
    [SerializeField] private float _timeUntilDestroy;
    [SerializeField] private Vector3 _particleOffset;
    [SerializeField] private ParticleSystem _explosionEffect;

    private Vector3 _rotation = Vector3.up;

    public static event UnityAction AnyDestroyed;

    private void Update()
    {
        Shoot();

        _timeUntilDestroy -= Time.deltaTime;
        if(_timeUntilDestroy <= 0)
        {
            Explode();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out Player player))
        {
            player.PushPlayer(transform, _pushPower);
            Explode();
        }
    }

    protected override void Shoot()
    {
        transform.eulerAngles += _rotation;
        Vector3 direction = (_player.transform.position - transform.position).normalized;
        transform.position += direction * _speed * Time.deltaTime;
    } 

    private void Explode()
    {
        var explosion = Instantiate(_explosionEffect, transform.position + _particleOffset, Quaternion.identity);
        AnyDestroyed?.Invoke();
        Destroy(gameObject);
    }
}

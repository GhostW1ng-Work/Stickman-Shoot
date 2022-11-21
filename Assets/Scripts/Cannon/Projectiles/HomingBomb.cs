using UnityEngine;

public class HomingBomb : Projectile
{
    [SerializeField] private float _pushPower;
    [SerializeField] private float _timeUntilDestroy;

    private Vector3 _rotation = Vector3.up;

    private void Update()
    {
        Shoot();

        _timeUntilDestroy -= Time.deltaTime;
        if(_timeUntilDestroy <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out Player player))
        {
            player.PushPlayer(transform, _pushPower);
            Destroy(gameObject);
        }
    }

    protected override void Shoot()
    {
        transform.eulerAngles += _rotation;
        //transform.LookAt(_player.transform);
        Vector3 direction = (_player.transform.position - transform.position).normalized;
        transform.position += direction * _speed * Time.deltaTime;
    } 
}

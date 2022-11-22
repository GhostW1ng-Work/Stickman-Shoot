using UnityEngine;
using UnityEngine.Events;

public class Boss : MonoBehaviour
{
    [SerializeField] private PlayerAttacker _player;
    [SerializeField] private float _health;
    [SerializeField] private float _pushPower;
    [SerializeField] private BossRagdoll _ragdoll;

    public static event UnityAction BossDied;

    private void Die() 
    {
        Debug.Log("Умер");
        Destroy(gameObject);
        BossRagdoll ragdoll = Instantiate(_ragdoll, transform.position, Quaternion.identity);
        ragdoll.PushRagdoll(_player.transform, _player.CurrentWeapon.PushPower);
        BossDied?.Invoke();
    }

    public void TakeDamage(float damage)
    {
        _health -= damage;

        if (_health <= 0)
            Die();
    }
}

using System.Collections;
using UnityEngine;

public class PlayerAttacker : MonoBehaviour
{
    [SerializeField] private Weapon _currentWeapon;

    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out Enemy enemy))
        {
            StartCoroutine(Attack());
            _currentWeapon.Attack(enemy);
        }

        if(collision.gameObject.TryGetComponent(out WeaponBox weaponBox))
        {
            SetWeapon(weaponBox.Weapon);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out WeaponBox weaponBox))
        {
            SetWeapon(weaponBox.Weapon);
        }
    }

    private void SetWeapon(Weapon weapon)
    {
        _currentWeapon = weapon;
    }

    private IEnumerator Attack()
    {
        _animator.SetBool("BaseballAttack", true);
        yield return new WaitForSeconds(0.01f);
        _animator.SetBool("BaseballAttack", false);
    }
}

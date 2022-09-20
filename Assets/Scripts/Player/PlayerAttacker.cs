using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class PlayerAttacker : MonoBehaviour
{
    [SerializeField] private Weapon _currentWeapon;

    private Animator _animator;
    private bool _canAttack;

    public event UnityAction Attacked;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _canAttack = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out Enemy enemy) && _canAttack == true)
        {
            StartCoroutine(Attack());
            _currentWeapon.Attack(enemy);
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
        _currentWeapon.gameObject.SetActive(false);
        _currentWeapon = weapon;
        weapon.gameObject.SetActive(true);
        _canAttack = true;
    }

    private IEnumerator Attack()
    {
        _animator.SetBool("BaseballAttack", true);
        yield return new WaitForSeconds(0.01f);
        _animator.SetBool("BaseballAttack", false);
        Attacked?.Invoke();
        _canAttack = false;
    }
}

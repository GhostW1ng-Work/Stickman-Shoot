using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(EnemyAnimatorSwitcher), typeof(Animator))]
public class EnemyAttacker : MonoBehaviour
{
    [SerializeField] private Weapon _unarmed;
    [SerializeField] private Weapon _currentWeapon;
    [SerializeField] private List<Weapon> _weapons;

    private EnemyAnimatorSwitcher _switcher;
    private Animator _animator;
    private bool _canAttack;

    public Weapon CurrentWeapon => _currentWeapon;

    public event UnityAction WeaponPickedUp;

    private void Start()
    {
        _switcher = GetComponent<EnemyAnimatorSwitcher>();
        _animator = GetComponent<Animator>();
        _canAttack = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out WeaponBox weaponBox))
        {
            SetWeapon(weaponBox.GetWeapon(_currentWeapon));
            Destroy(weaponBox.gameObject);
        }

        if (other.TryGetComponent(out Player player) && _canAttack == true)
        {
            StartCoroutine(Attack());
            _currentWeapon.Attack(player);
        }
    }

    private void SetWeapon(Weapon weapon)
    {
        Debug.Log("Взяли");
        foreach (Weapon newWeapon in _weapons)
        {
            Debug.Log("Лист");
            if(newWeapon.WeaponName == weapon.WeaponName)
            {
                Debug.Log("Зашли");
                _currentWeapon.gameObject.SetActive(false);
                _currentWeapon = newWeapon;
                newWeapon.gameObject.SetActive(true);
                _canAttack = true;
                WeaponPickedUp?.Invoke();
            }
        } 
    }

    private IEnumerator Attack()
    {
        _animator.SetBool("BaseballAttack", true);
        yield return new WaitForSeconds(0.01f);
        _animator.SetBool("BaseballAttack", false);
        SetUnarmed();
    }

    private void SetUnarmed()
    {
        _currentWeapon.gameObject.SetActive(false);
        _canAttack = false;
        _currentWeapon = _unarmed;
        _switcher.SetWeaponAnimation(_currentWeapon);
    }
}

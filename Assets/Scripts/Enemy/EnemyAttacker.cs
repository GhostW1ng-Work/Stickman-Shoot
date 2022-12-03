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
    private int _collisionCount;

    public Weapon CurrentWeapon => _currentWeapon;
    public int CollisionCount => _collisionCount;

    public static event UnityAction AnyAttacked;
    public event UnityAction Attacked;
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
            if(player.GetPlayerAttackerCollisionCount() < 1)
            {
                _collisionCount++;
                StartCoroutine(Attack());
                _currentWeapon.Attack(transform, player);
            }
        }

        if (other.TryGetComponent(out Enemy enemy) && _canAttack == true)
        {
            if(enemy.IsAttacked == false && enemy.GetEnemyAttackerCollisionCount() < 1)
            {
                StartCoroutine(Attack());
                _currentWeapon.Attack(transform, enemy);
            }
        }
    }

    private void SetWeapon(Weapon weapon)
    {
        foreach (Weapon newWeapon in _weapons)
        {
            if(newWeapon.WeaponName == weapon.WeaponName)
            {
                _currentWeapon.gameObject.SetActive(false);
                _currentWeapon = newWeapon;
                newWeapon.gameObject.SetActive(true);
                _canAttack = true;
                
            }
        }
        WeaponPickedUp?.Invoke();
    }

    private IEnumerator Attack()
    {
        _animator.SetBool("BaseballAttack", true);
        yield return new WaitForSeconds(0.01f);
        _animator.SetBool("BaseballAttack", false);
        AnyAttacked?.Invoke();
        Attacked?.Invoke();
        SetUnarmed();
        _collisionCount--;
    }

    private void SetUnarmed()
    {
        _currentWeapon.gameObject.SetActive(false);
        _canAttack = false;
        _currentWeapon = _unarmed;
        _switcher.SetWeaponAnimation(_currentWeapon);
    }
}

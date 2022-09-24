using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class PlayerAttacker : MonoBehaviour
{
    [SerializeField] private Weapon _unarmed;
    [SerializeField] private Weapon _currentWeapon;

    private PlayerAnimatorSwitcher _switcher;
    private Animator _animator;
    private bool _canAttack;

    public Weapon CurrentWeapon => _currentWeapon;

    public event UnityAction Attacked;
    public event UnityAction WeaponPickedUp;

    private void Start()
    {
        _switcher = GetComponent<PlayerAnimatorSwitcher>();
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
        _currentWeapon.CloseImage();
        _currentWeapon.gameObject.SetActive(false);
        _currentWeapon = weapon;
        weapon.gameObject.SetActive(true);
        weapon.ShowImage();
        _canAttack = true;
        WeaponPickedUp?.Invoke();
    }

    private IEnumerator Attack()
    {
        _animator.SetBool("BaseballAttack", true);
        yield return new WaitForSeconds(0.01f);
        _animator.SetBool("BaseballAttack", false);
        Attacked?.Invoke();
        SetUnarmed();
    }

    private void SetUnarmed()
    {
        _canAttack = false;
        _currentWeapon = _unarmed;
        _switcher.SetWeaponAnimation(_currentWeapon);
    }
}

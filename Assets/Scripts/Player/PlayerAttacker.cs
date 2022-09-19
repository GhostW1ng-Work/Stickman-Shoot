using System.Collections;
using UnityEngine;

public class PlayerAttacker : MonoBehaviour
{
    [SerializeField] private float _pushForce;
    [SerializeField] private Weapon[] _weapons;

    private Weapon _currentWeapon;
    private Animator _animator;
    private int _currentWeaponIndex;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _currentWeaponIndex = 0;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            if(_currentWeaponIndex < _weapons.Length)
            {
                _currentWeapon = _weapons[_currentWeaponIndex];
                _weapons[_currentWeaponIndex].gameObject.SetActive(true);
                for (int i = 0; i < _weapons.Length; i++)
                {
                    if (i != _currentWeaponIndex)
                        _weapons[i].gameObject.SetActive(false);
                }
                _currentWeaponIndex++;  
            }
            else
            {
                _currentWeaponIndex = 0;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out Enemy enemy))
        {
            StartCoroutine(Attack());
            _currentWeapon.Attack(enemy);
        }
    }

    private IEnumerator Attack()
    {
        _animator.SetBool("BaseballAttack", true);
        yield return new WaitForSeconds(0.01f);
        _animator.SetBool("BaseballAttack", false);
    }
}

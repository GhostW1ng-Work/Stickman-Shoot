using System.Collections;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(PlayerAnimatorSwitcher), typeof(Animator))]
public class PlayerAttacker : MonoBehaviour
{
    [SerializeField] private Weapon _unarmed;
    [SerializeField] private Weapon _currentWeapon;
    [SerializeField] private PlayerGunner _gunner;
    [SerializeField] private VideoAdShower _videoAdShower;
    [SerializeField] private AudioSource _pickUpWeaponSound;

    private PlayerAnimatorSwitcher _switcher;
    private Animator _animator;
    private bool _canAttack;
    private int _collisionCount;


    public Weapon CurrentWeapon => _currentWeapon;
    public int CollisionCount => _collisionCount;

    public event UnityAction Attacked;
    public event UnityAction WeaponPickedUp;
    public static event UnityAction AnyAttacked;

    private void OnEnable()
    {
        _videoAdShower.VideoShowed += SetUnarmed;
    }

    private void OnDisable()
    {
        _videoAdShower.VideoShowed -= SetUnarmed;
    }

    private void Start()
    {
        _videoAdShower.VideoShowed += SetUnarmed;
        _switcher = GetComponent<PlayerAnimatorSwitcher>();
        _animator = GetComponent<Animator>();
        _canAttack = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out WeaponBox weaponBox))
        {
            _pickUpWeaponSound.Play();
            SetWeapon(weaponBox.GetWeapon(_currentWeapon));
            Destroy(weaponBox.gameObject);
        }

        if (other.TryGetComponent(out Enemy enemy) && _canAttack == true)
        {
            if (enemy.IsAttacked == false && enemy.GetEnemyAttackerCollisionCount() < 1)
            {
                _collisionCount++;
                StartCoroutine(Attack());
                _currentWeapon.Attack(enemy);
            }
        }

        if(other.TryGetComponent(out Boss boss) && _canAttack == true)
        {
            StartCoroutine(Attack());
            boss.TakeDamage(_currentWeapon.Damage);
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

        if (_currentWeapon.GetComponent<IceCube>())
            _gunner.enabled = true;
        else
            _gunner.enabled = false;

    }

    private IEnumerator Attack()
    {
        _animator.SetBool("BaseballAttack", true);
        yield return new WaitForSeconds(0.01f);
        _animator.SetBool("BaseballAttack", false);
        Attacked?.Invoke();
        AnyAttacked?.Invoke();
        SetUnarmed();
        _collisionCount--;
    }

    private void SetUnarmed()
    {
        _currentWeapon.CloseImage();
        _currentWeapon.gameObject.SetActive(false);
        _canAttack = false;
        _currentWeapon = _unarmed;
        _switcher.SetWeaponAnimation(_currentWeapon);
        _gunner.enabled = false;
    }
}

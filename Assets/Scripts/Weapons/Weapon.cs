using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public abstract class Weapon : MonoBehaviour
{
    [SerializeField] protected PlayerAttacker _player;
    [SerializeField] protected Image _weaponImage;
    [SerializeField] protected AudioSource _punchAudio;
    [SerializeField] protected float _pushPower;
    [SerializeField] protected float _damage;
    [SerializeField] protected float _timeToShutdown;
    [SerializeField] protected string _weaponName;

    public string WeaponName => _weaponName;
    public float Damage => _damage;
    public float PushPower => _pushPower;

    private void OnEnable()
    {
        PlayerAttacker.AnyAttacked += OnAnyAttacked;
        EnemyAttacker.AnyAttacked += OnAnyAttacked;
    }

    private void OnDisable()
    {
        PlayerAttacker.AnyAttacked -= OnAnyAttacked;
        EnemyAttacker.AnyAttacked -= OnAnyAttacked; 
    }

    private void OnAnyAttacked()
    {
        _punchAudio.Play();
    }

    public void ShowImage()
    {
        _weaponImage.gameObject.SetActive(true);
    }

    public void CloseImage()
    {
        _weaponImage.gameObject.SetActive(false);
    }

    public abstract void Attack(Enemy enemy);

    public abstract void Attack(Transform attackEnemy, Enemy enemy);

    public abstract void Attack(Transform enemyTransform, Player player);

}

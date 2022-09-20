using System.Collections;
using UnityEngine;

public class Baseball : Weapon
{
    [SerializeField] private PlayerAttacker _player;
    [SerializeField] private float _pushPower;

    private void OnEnable()
    {
        _player.Attacked += OnAttacked;
    }

    private void OnDisable()
    {
        _player.Attacked -= OnAttacked;
    }

    private void OnAttacked()
    {
        StartCoroutine(WeaponSetActive());
    }

    private IEnumerator WeaponSetActive()
    {
        yield return new WaitForSeconds(0.5f);
        gameObject.SetActive(false);
    }

    public override void Attack(Enemy enemy)
    {
        enemy.PushEnemy(_player.transform, _pushPower);
    }
}

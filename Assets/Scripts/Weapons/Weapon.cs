using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    [SerializeField] protected PlayerAttacker _player;
    [SerializeField] protected float _pushPower;
    [SerializeField] protected float _timeToShutdown;

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
        yield return new WaitForSeconds(_timeToShutdown);
        gameObject.SetActive(false);
    }

    public abstract void Attack(Enemy enemy);
}

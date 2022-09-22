using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public abstract class Weapon : MonoBehaviour
{
    [SerializeField] protected PlayerAttacker _player;
    [SerializeField] protected Image _weaponImage;
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
        _weaponImage.gameObject.SetActive(false);
        gameObject.SetActive(false);

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
}

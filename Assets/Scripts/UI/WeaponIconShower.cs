using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponIconShower : MonoBehaviour
{
    [SerializeField] private PlayerAttacker _player;
    [SerializeField] private GameObject _weaponIconPanel;

    private void OnEnable()
    {
        _player.Attacked += OnAttacked;
        _player.WeaponPickedUp += OnWeaponPickedUp;
            
    }

    private void OnDisable()
    {
        _player.Attacked -= OnAttacked;
        _player.WeaponPickedUp -= OnWeaponPickedUp;
    }

    private void OnWeaponPickedUp()
    {
        _weaponIconPanel.gameObject.SetActive(true);
    }

    private void OnAttacked()
    {
        _weaponIconPanel.gameObject.SetActive(false);
    }
}

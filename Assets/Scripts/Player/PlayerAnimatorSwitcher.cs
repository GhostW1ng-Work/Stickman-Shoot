using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimatorSwitcher : MonoBehaviour
{
    private PlayerAttacker _attacker;
    private Animator _animator;
    private int _baseLayerIndex;
    private int _baseballLayerIndex;
    private int _boxLayerIndex;
    private int _iceCubeLayerIndex;

    private void OnEnable()
    {
        _attacker.WeaponPickedUp += OnWeaponPickedUp;
    }

    private void OnDisable()
    {
        _attacker.WeaponPickedUp -= OnWeaponPickedUp;
    }

    private void Awake()
    {
        _attacker = GetComponent<PlayerAttacker>();
        _animator = GetComponent<Animator>();

        _baseLayerIndex = _animator.GetLayerIndex("Base Layer");
        _baseballLayerIndex = _animator.GetLayerIndex("Baseball");
        _boxLayerIndex = _animator.GetLayerIndex("Box");
        _iceCubeLayerIndex = _animator.GetLayerIndex("IceCube");
    }

    private void OnWeaponPickedUp()
    {
        SetWeaponAnimation(_attacker.CurrentWeapon);
    }

    public void SetWeaponAnimation(Weapon weapon)
    {
        switch (weapon.WeaponName)
        {
            case "BaseballBat":
                _animator.SetLayerWeight(_boxLayerIndex, 0);
                _animator.SetLayerWeight(_iceCubeLayerIndex, 0);
                _animator.SetLayerWeight(_baseLayerIndex, 0);
                _animator.SetLayerWeight(_baseballLayerIndex, 1);
                break;
            case "BoxGloves":
                _animator.SetLayerWeight(_boxLayerIndex, 1);
                _animator.SetLayerWeight(_iceCubeLayerIndex, 0);
                _animator.SetLayerWeight(_baseLayerIndex, 0);
                _animator.SetLayerWeight(_baseballLayerIndex, 0);
                break;
            case "IceCube":
                _animator.SetLayerWeight(_boxLayerIndex, 0);
                _animator.SetLayerWeight(_iceCubeLayerIndex, 1);
                _animator.SetLayerWeight(_baseLayerIndex, 0);
                _animator.SetLayerWeight(_baseballLayerIndex, 0);
                break;
            default:
                _animator.SetLayerWeight(_boxLayerIndex, 0);
                _animator.SetLayerWeight(_iceCubeLayerIndex, 0);
                _animator.SetLayerWeight(_baseLayerIndex, 1);
                _animator.SetLayerWeight(_baseballLayerIndex, 0);
                break;
        }
    }
}

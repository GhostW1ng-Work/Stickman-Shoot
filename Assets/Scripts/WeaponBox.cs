using UnityEngine;

public class WeaponBox : MonoBehaviour
{
    [SerializeField] private Weapon[] _weapons;

    public Weapon GetWeapon(Weapon weapon)
    {
        int weaponIndex = Random.Range(0, _weapons.Length);
        return weapon = _weapons[weaponIndex];
    }
}

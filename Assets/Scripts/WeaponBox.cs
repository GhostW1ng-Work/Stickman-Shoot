using UnityEngine;

public class WeaponBox : MonoBehaviour
{
    [SerializeField] private Weapon _weapon;

    public Weapon Weapon => _weapon;
}

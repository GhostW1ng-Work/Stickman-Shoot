using UnityEngine;

public class IceCube : Weapon
{
    public override void Attack(Enemy enemy)
    {
        enemy.Freeze(this);
    }
}

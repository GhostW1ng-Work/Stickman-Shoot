using UnityEngine;

public class Unarmed : Weapon
{
    public override void Attack(Enemy enemy)
    {
    }

    public override void Attack(Transform attackEnemy, Enemy enemy)
    {
    }

    public override void Attack(Transform enemyTransform, Player player)
    {
    }
}

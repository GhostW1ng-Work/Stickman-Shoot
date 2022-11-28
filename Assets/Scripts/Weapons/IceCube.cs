using UnityEngine;

public class IceCube : Weapon
{
    public override void Attack(Enemy enemy)
    {
        enemy.Freeze();
    }

    public override void Attack(Transform attackEnemy, Enemy enemy)
    {
        enemy.Freeze();
    }

    public override void Attack(Transform enemyTransform, Player player)
    {
        Debug.Log("Заморозило");
    }
}

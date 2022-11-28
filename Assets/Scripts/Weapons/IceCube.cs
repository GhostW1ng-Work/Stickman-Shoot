using UnityEngine;

public class IceCube : Weapon
{
    public override void Attack(Enemy enemy)
    {
        enemy.Freeze();
    }

    public override void Attack(Player player)
    {
        Debug.Log("Заморозило");
    }
}

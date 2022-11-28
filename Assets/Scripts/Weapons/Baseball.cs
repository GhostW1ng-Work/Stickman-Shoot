using UnityEngine;

public class Baseball : Weapon
{
    public override void Attack(Enemy enemy)
    {
        enemy.PushEnemy(_player.transform, _pushPower);
    }

    public override void Attack(Player player)
    {
        Debug.Log("уебало битой");
    }
}

using UnityEngine;

public class BoxGlove : Weapon
{
    private void Update()
    {
    }

    public override void Attack(Enemy enemy)
    {
        enemy.PushEnemy(_player.transform, _pushPower);
    }

    public override void Attack(Transform attackEnemy, Enemy enemy)
    {
        enemy.PushEnemy(attackEnemy, _pushPower);
    }

    public override void Attack(Transform enemyTransform, Player player)
    {
        player.PushPlayer(enemyTransform, _pushPower * 10);
    }
}

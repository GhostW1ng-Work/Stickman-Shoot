public class BoxGlove : Weapon
{
    private void Update()
    {
    }

    public override void Attack(Enemy enemy)
    {
        enemy.PushEnemy(_player.transform, _pushPower);
    }
}

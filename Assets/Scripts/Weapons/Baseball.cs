using UnityEngine;

public class Baseball : Weapon
{
    [SerializeField] private PlayerMover _player;
    [SerializeField] private float _pushPower;

    public override void Attack(Enemy enemy)
    {
        enemy.PushEnemy(_player.transform, _pushPower);
    }
}

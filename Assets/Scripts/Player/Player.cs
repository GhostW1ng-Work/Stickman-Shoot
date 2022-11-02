using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private EnemyCounter _enemyCounter;
    [SerializeField] private FloatingJoystick _joystick;

    private Animator _animator;
    private PlayerMover _mover;
    private PlayerAttacker _attacker;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _mover = GetComponent<PlayerMover>();
        _attacker = GetComponent<PlayerAttacker>();
    }

    private void OnEnable()
    {
        _enemyCounter.EnemiesPlucked += OnEnemiesPlucked;
    }

    private void OnDisable()
    {
        _enemyCounter.EnemiesPlucked -= OnEnemiesPlucked;
    }

    private void OnEnemiesPlucked()
    {
        _joystick.gameObject.SetActive(false);
        _animator.SetBool("Dance", true);
        _attacker.enabled = false;
    }
}

using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private EnemyCounter _enemyCounter;
    [SerializeField] private FloatingJoystick _joystick;
    [SerializeField] private AudioSource _winSound;

    private Animator _animator;
    private PlayerAttacker _attacker;
    private bool _isWin = false;

    private void Start()
    {
        _animator = GetComponent<Animator>();
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
        if (!_isWin)
        {
            _isWin = true;
            _winSound.PlayOneShot(_winSound.clip);
            _joystick.gameObject.SetActive(false);
            _animator.SetBool("Dance", true);
            _attacker.enabled = false;
        }
    }
}

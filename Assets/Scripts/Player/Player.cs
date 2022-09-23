using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private EnemyCounter _enemyCounter;
    [SerializeField] private FloatingJoystick _joystick;

    private Animator _animator;
    private PlayerMover _mover;
    private PlayerAttacker _attacker;
    private bool _isVictory;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _mover = GetComponent<PlayerMover>();
        _attacker = GetComponent<PlayerAttacker>();
        _isVictory = false;
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
        _mover.enabled = false;
        _attacker.enabled = false;
    }
}

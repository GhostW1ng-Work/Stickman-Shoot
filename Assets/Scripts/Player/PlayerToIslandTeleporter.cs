using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class PlayerToIslandTeleporter : MonoBehaviour
{
    [SerializeField] private EnemyOnArenaCounter _enemyOnArenaCounter;
    [SerializeField] private Transform _teleportPosition;
    [SerializeField] private ParticleSystem _teleportVFX;
    [SerializeField] private float _timeUntilTeleport;
    [SerializeField] private float _timeToGiveControl;

    public static event UnityAction TeleportEnded;
    public static event UnityAction TeleportStarted;

    private void OnEnable()
    {
        _enemyOnArenaCounter.EnemiesOnArenaDied += OnEnemiesOnArenaDied;
    }

    private void OnDisable()
    {
        _enemyOnArenaCounter.EnemiesOnArenaDied += OnEnemiesOnArenaDied;
    }

    private void OnEnemiesOnArenaDied()
    {
        StartCoroutine(TeleportPlayer());
    }

    private IEnumerator TeleportPlayer()
    {
        TeleportStarted?.Invoke();

        Instantiate(_teleportVFX, transform.position, Quaternion.identity);
        transform.position = _teleportPosition.position;
        yield return new WaitForSeconds(_timeUntilTeleport);
        Instantiate(_teleportVFX, transform.position, Quaternion.Euler(0,1,0));

        TeleportEnded?.Invoke();
    }
}

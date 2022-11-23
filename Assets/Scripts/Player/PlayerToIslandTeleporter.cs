using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class PlayerToIslandTeleporter : MonoBehaviour
{
    [SerializeField] private EnemyOnArenaCounter[] _enemyOnArenaCounters;
    [SerializeField] private Transform[] _teleportPositions;
    [SerializeField] private ParticleSystem _teleportVFX;
    [SerializeField] private AudioSource _teleportSound;
    [SerializeField] private float _timeUntilTeleport;
    [SerializeField] private float _timeToGiveControl;

    private int _teleportPositionIndex = -1;

    public static event UnityAction TeleportEnded;
    public static event UnityAction TeleportStarted;

    private void OnEnable()
    {
        foreach (EnemyOnArenaCounter enemyOnArenaCounter in _enemyOnArenaCounters)
        {
            enemyOnArenaCounter.EnemiesOnArenaDied += OnEnemiesOnArenaDied;
        }
       
    }

    private void OnDisable()
    {
        foreach (EnemyOnArenaCounter enemyOnArenaCounter in _enemyOnArenaCounters)
        {
            enemyOnArenaCounter.EnemiesOnArenaDied -= OnEnemiesOnArenaDied;
        }
    }

    private void OnEnemiesOnArenaDied()
    {   
        StartCoroutine(TeleportPlayer());
    }

    private IEnumerator TeleportPlayer()
    {
        _teleportPositionIndex++;
        TeleportStarted?.Invoke();

        Instantiate(_teleportVFX, transform.position, Quaternion.identity);
        _teleportSound.Play();
        transform.position = _teleportPositions[_teleportPositionIndex].transform.position;
        yield return new WaitForSeconds(_timeUntilTeleport);
        Instantiate(_teleportVFX, transform.position, Quaternion.Euler(0, 1, 0));

        TeleportEnded?.Invoke();
    }
}

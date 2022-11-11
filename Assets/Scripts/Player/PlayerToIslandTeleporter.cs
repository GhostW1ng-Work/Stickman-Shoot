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

    private MobileMover _mobileMover;
    private DesktopMover _desktopMover;

    public static event UnityAction PlayerTeleported; 

    private void OnEnable()
    {
        _enemyOnArenaCounter.EnemiesOnArenaDied += OnEnemiesOnArenaDied;
    }

    private void OnDisable()
    {
        _enemyOnArenaCounter.EnemiesOnArenaDied += OnEnemiesOnArenaDied;
    }

    private void Start()
    {
        _mobileMover = GetComponent<MobileMover>();
        _desktopMover = GetComponent<DesktopMover>();
    }

    private void OnEnemiesOnArenaDied()
    {
        StartCoroutine(TeleportPlayer());
    }

    private IEnumerator TeleportPlayer()
    {
        _mobileMover.enabled = false;
        _desktopMover.enabled = false;

        Instantiate(_teleportVFX, transform.position, Quaternion.identity);
        transform.position = _teleportPosition.position;
        yield return new WaitForSeconds(_timeUntilTeleport);
        Instantiate(_teleportVFX, transform.position, Quaternion.Euler(0,1,0));
        PlayerTeleported?.Invoke();

        yield return new WaitForSeconds(_timeToGiveControl);
        _desktopMover.enabled = true;
    }
}

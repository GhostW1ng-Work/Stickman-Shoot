using UnityEngine;

public class ArenaCount : MonoBehaviour
{
    public static ArenaCount Instance { get; private set; }

    private int _currentArenaCount = 0;

    public int CurrentArenaCount => _currentArenaCount;

    private void Awake()
    {
        if(Instance != null)
        {
            Debug.LogError("Extra Instance");
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.U))
        {
            _currentArenaCount++;
        }
    }

    private void OnEnable()
    {
        EnemyOnArenaCounter.EnemiesOnAnyArenaDied += OnEnemiesOnAnyArenaDied;
    }

    private void OnDisable()
    {
        EnemyOnArenaCounter.EnemiesOnAnyArenaDied -= OnEnemiesOnAnyArenaDied;
    }

    private void OnEnemiesOnAnyArenaDied()
    {
        _currentArenaCount++;
    }
}

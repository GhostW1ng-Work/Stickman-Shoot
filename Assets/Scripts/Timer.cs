using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] private MoveToStartPanelDisabler _moveToStartPanelDisabler;

    private float _elapsedTime;
    private bool _isStarted;

    public float ElapsedTime => _elapsedTime;

    private void OnEnable()
    {
        _moveToStartPanelDisabler.AnyKeyPressed += OnAnyKeyPressed;
    }

    private void OnDisable()
    {
        _moveToStartPanelDisabler.AnyKeyPressed -= OnAnyKeyPressed;
    }

    private void Start()
    {
        _isStarted = false;
    }

    private void Update()
    {
        if(_isStarted)
            _elapsedTime += Time.deltaTime;
    }

    private void OnAnyKeyPressed()
    {
        _isStarted = true;
    }

    public void ResetTimer()
    {
        _elapsedTime = 0;
    }
}

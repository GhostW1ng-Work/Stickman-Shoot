using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class LevelCounterText : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _levelCounterText;
    [SerializeField] private GameObject _levelCounterTextGameObject;

    private MoveToStartPanelDisabler _moveToStart;

    private void Awake()
    {
        _moveToStart = GetComponentInChildren<MoveToStartPanelDisabler>();
    }

    private void Start()
    {
        _levelCounterText.text = (SceneManager.GetActiveScene().buildIndex + 1).ToString();
    }

    private void OnEnable()
    {
        _moveToStart.AnyKeyPressed += OnAnyKeyPressed;
    }

    private void OnDisable()
    {
        _moveToStart.AnyKeyPressed -= OnAnyKeyPressed;
    }

    private void OnAnyKeyPressed()
    {
        _levelCounterTextGameObject.SetActive(false);
    }
}

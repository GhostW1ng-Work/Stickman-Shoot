using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class NextLevelButton : MonoBehaviour
{
    [SerializeField] private LevelSwitcher _levelSwitcher;

    private Button _button;

    private void Start()
    {
        _button = GetComponent<Button>();
        _button.onClick.AddListener(SetNextLevel);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(SetNextLevel);
    }

    private void SetNextLevel()
    {
        _levelSwitcher.NextLevel();
    }
}

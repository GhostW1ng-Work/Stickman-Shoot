using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class LevelCounterText : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _levelCounterText;

    private void Start()
    {
        _levelCounterText.text = (SceneManager.GetActiveScene().buildIndex + 1).ToString();
    }
}

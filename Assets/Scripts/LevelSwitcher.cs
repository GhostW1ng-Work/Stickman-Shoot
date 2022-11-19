using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSwitcher : MonoBehaviour
{
    private readonly int _defaultLevel = 0;
    private int _levelIndex = 0;
    private static bool _isLoaded = false;

    public int LevelIndex => _levelIndex;

    private void Start()
    {
        if (!_isLoaded)
        {
            _isLoaded = true;
            _levelIndex = PlayerPrefs.GetInt("CurrentLevel", _defaultLevel);
            SceneManager.LoadScene(_levelIndex);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            _levelIndex = _defaultLevel;
            PlayerPrefs.SetInt("CurrentLevel", _levelIndex);
            SceneManager.LoadScene(_levelIndex);
            PlayerPrefs.Save();

        }
    }

    public void NextLevel()
    {
        if(SceneManager.GetActiveScene().buildIndex + 1 >= SceneManager.sceneCountInBuildSettings)
        {
            _levelIndex = _defaultLevel;
            PlayerPrefs.SetInt("CurrentLevel", _levelIndex);
            SceneManager.LoadScene(_levelIndex);
            PlayerPrefs.Save();
        }
        else
        {
            _levelIndex = SceneManager.GetActiveScene().buildIndex + 1;
            PlayerPrefs.SetInt("CurrentLevel", _levelIndex);
            SceneManager.LoadScene(_levelIndex);
            PlayerPrefs.Save();
        }
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}

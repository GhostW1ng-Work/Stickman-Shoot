using Agava.YandexGames;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSwitcher : MonoBehaviour
{
    private int _levelIndex = 0;

    public void NextLevel()
    {
        if(SceneManager.GetActiveScene().buildIndex + 1 >= SceneManager.sceneCountInBuildSettings)
        {
            _levelIndex = 0;
            PlayerPrefs.DeleteKey("CurrentLevel");
            PlayerPrefs.SetInt("CurrentLevel", _levelIndex);
            SceneManager.LoadScene(0);
            PlayerPrefs.Save();
        }
        else
        {
            _levelIndex = SceneManager.GetActiveScene().buildIndex;
            PlayerPrefs.DeleteKey("CurrentLevel");
            PlayerPrefs.SetInt("CurrentLevel", _levelIndex);
            SceneManager.LoadScene(_levelIndex + 1); 
            PlayerPrefs.Save();
        }
        
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}

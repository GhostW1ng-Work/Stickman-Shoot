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
            SceneManager.LoadScene(0);
        }
        else
        {
            _levelIndex = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(_levelIndex + 1); 
        }
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}

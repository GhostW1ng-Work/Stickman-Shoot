using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSwitcher : MonoBehaviour
{
    private int _levelIndex = 0;

    public void NextLevel()
    {
        _levelIndex = SceneManager.GetActiveScene().buildIndex;
        if(_levelIndex < SceneManager.sceneCount)
        {
            SceneManager.LoadScene(_levelIndex + 1);
        }
        else
        {
            _levelIndex = 0;
            SceneManager.LoadScene(_levelIndex);
        }
        


    }
}

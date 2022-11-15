using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    private void Start()
    {
        DontDestroyOnLoad(gameObject);
        LoadGame();

    }

    private void LoadGame()
    {
        if (PlayerPrefs.HasKey("CurrentLevel"))
        {
            SceneManager.LoadScene(PlayerPrefs.GetInt("CurrentLevel"));
        }
    }

}

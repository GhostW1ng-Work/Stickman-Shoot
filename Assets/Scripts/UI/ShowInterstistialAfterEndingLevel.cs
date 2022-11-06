using UnityEngine;

public class ShowInterstistialAfterEndingLevel : MonoBehaviour
{
    [SerializeField] private PlayerChecker _playerChecker;
    [SerializeField] private EnemyCounter _enemyCounter;

    private void OnEnable()
    {
        _playerChecker.PlayerFalled += ShowInterstitial;
        _enemyCounter.EnemiesPlucked += ShowInterstitial;
    }

    private void OnDisable()
    {
        _playerChecker.PlayerFalled -= ShowInterstitial;
        _enemyCounter.EnemiesPlucked -= ShowInterstitial;
    }

    public void ShowInterstitial()
    {
#if UNITY_WEBGL && !UNITY_EDITOR
        Agava.YandexGames.InterstitialAd.Show();
#endif
    }
}

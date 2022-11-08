using System.Collections;
using UnityEngine;

public class ShowInterstistialAfterEndingLevel : MonoBehaviour
{
    [SerializeField] private EnemyCounter _enemyCounter;
    [SerializeField] private float _waitForShowInterstitial;

    private void OnEnable()
    {
        _enemyCounter.EnemiesPlucked += ShowInterstitial;
    }

    private void OnDisable()
    {
        _enemyCounter.EnemiesPlucked -= ShowInterstitial;
    }

    public void ShowInterstitial()
    {
#if UNITY_WEBGL && !UNITY_EDITOR
        WaitForShowInterstitial();
#endif
    }

    private IEnumerator WaitForShowInterstitial()
    {
        yield return new WaitForSeconds(_waitForShowInterstitial);
        Agava.YandexGames.InterstitialAd.Show();
    }
}

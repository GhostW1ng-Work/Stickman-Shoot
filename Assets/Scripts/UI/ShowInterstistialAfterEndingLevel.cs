using System.Collections;
using UnityEngine;

public class ShowInterstistialAfterEndingLevel : MonoBehaviour
{
    [SerializeField] private EnemyCounter _enemyCounter;
    [SerializeField] private float _waitForShowInterstitial;

    private void OnEnable()
    {
        _enemyCounter.EnemiesPlucked += ShowInterstitial;
        Boss.BossDied += ShowInterstitial;
    }

    private void OnDisable()
    {
        _enemyCounter.EnemiesPlucked -= ShowInterstitial;
        Boss.BossDied -= ShowInterstitial;
    }

    public void ShowInterstitial()
    {
#if UNITY_WEBGL && !UNITY_EDITOR
        StartCoroutine(WaitForShowInterstitial());
#endif
    }

    private IEnumerator WaitForShowInterstitial()
    {
        yield return new WaitForSeconds(_waitForShowInterstitial);
        Agava.YandexGames.InterstitialAd.Show();
    }
}

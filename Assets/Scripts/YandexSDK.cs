using Agava.YandexGames;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class YandexSDK : MonoBehaviour
{
    [SerializeField] private InputField _playerDataTextField;

    private void Awake()
    {
        YandexGamesSdk.CallbackLogging = true;
    }

    private IEnumerator Start()
    {
        yield return YandexGamesSdk.Initialize();
    }

    public void ShowInterstitialAd()
    {
        InterstitialAd.Show();
    }

    public void ShowVideoAd()
    {
        VideoAd.Show();
    }

    public void OnSetPlayerData()
    {
        PlayerAccount.SetPlayerData(_playerDataTextField.text);
    }

    public void OnGetPlayerData()
    {
        PlayerAccount.GetPlayerData((data) => _playerDataTextField.text = data);
    }
}

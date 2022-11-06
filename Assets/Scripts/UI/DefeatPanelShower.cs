using UnityEngine;

public class DefeatPanelShower : MonoBehaviour
{
    [SerializeField] private PlayerChecker _playerChecker;
    [SerializeField] private VideoAdShower _videoAdShower;
    [SerializeField] private GameObject _defeatPanel;
    [SerializeField] private GameObject _weaponPanel;

    private void OnEnable()
    {
        _playerChecker.PlayerFalled += OnPlayerFalled;
        _videoAdShower.VideoShowed += OnVideoAdShowed;
    }

    private void OnDisable()
    {
        _playerChecker.PlayerFalled -= OnPlayerFalled;
        _videoAdShower.VideoShowed -= OnVideoAdShowed;
    }

    private void OnPlayerFalled()
    {
        _defeatPanel.SetActive(true);
        _weaponPanel.SetActive(false);
    }

    private void OnVideoAdShowed()
    {
        _defeatPanel.SetActive(false);
    }
}

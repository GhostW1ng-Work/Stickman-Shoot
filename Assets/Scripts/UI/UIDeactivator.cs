using UnityEngine;

public class UIDeactivator : MonoBehaviour
{
    [SerializeField] private PlayerChecker _playerChecker;
    [SerializeField] private GameObject _defeatPanel;
    [SerializeField] private GameObject _weaponPanel;

    private void OnEnable()
    {
        _playerChecker.PlayerFalled += OnPlayerFalled;
    }

    private void OnDisable()
    {
        _playerChecker.PlayerFalled -= OnPlayerFalled;
    }

    private void OnPlayerFalled()
    {
        _defeatPanel.SetActive(true);
        _weaponPanel.SetActive(false);
    }
}

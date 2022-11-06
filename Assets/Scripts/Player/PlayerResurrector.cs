using UnityEngine;

public class PlayerResurrector : MonoBehaviour
{
    [SerializeField] private VideoAdShower _videoAdShower;
    [SerializeField] private Player _player;

    private void OnEnable()
    {
        _videoAdShower.VideoShowed += OnVideoAdShowed;
    }

    private void OnDisable()
    {
        _videoAdShower.VideoShowed -= OnVideoAdShowed;
    }

    private void Start()
    {
        transform.position = _player.transform.position;
    }

    private void OnVideoAdShowed()
    {
        _player.gameObject.SetActive(true);
        _player.transform.position = transform.position;
    }
}

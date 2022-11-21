using UnityEngine;
using UnityEngine.UI;

public class SoundMuter : MonoBehaviour
{
    [SerializeField] private Sprite _audioOn;
    [SerializeField] private Sprite _audioOff;

    private Image _currentImage;
    private Button _button;
    private bool _isAudioOn;

    private void Awake()
    {
        _button = GetComponent<Button>();
    }

    private void OnEnable()
    {
        _button.onClick.AddListener(TryMuteAudio);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(TryMuteAudio);
    }

    private void Start()
    {
        
        _currentImage = GetComponent<Image>();

        if (!_isAudioOn)
        {
            _currentImage.sprite = _audioOff;
        }
        else
        {
            _currentImage.sprite = _audioOn;
        }
    }

    private void MuteAudio()
    {
        _isAudioOn = false;
        _currentImage.sprite = _audioOff;
        AudioListener.volume = 0;
    }

    private void UnmuteAudio()
    {
        _isAudioOn = true;
        _currentImage.sprite = _audioOn;
        AudioListener.volume = 1;
    }

    public void TryMuteAudio()
    {
        if (_isAudioOn)
        {
            MuteAudio();
        }
        else
        {
            UnmuteAudio();
        }
    }
}

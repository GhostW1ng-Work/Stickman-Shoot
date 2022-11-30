using UnityEngine;
using UnityEngine.UI;

public class SoundMuter : MonoBehaviour
{
    [SerializeField] private Sprite _audioOn;
    [SerializeField] private Sprite _audioOff;
    [SerializeField] private VideoAdShower _videoAdShower;

    private Image _currentImage;
    private Button _button;
    private int _isAudioOnInt;

    private void Awake()
    {
        _button = GetComponent<Button>();
    }

    private void OnEnable()
    {
        _videoAdShower.VideoShowed += OnVideoShowed;
        _videoAdShower.VideoClosed += OnVideoClosed;
        _button.onClick.AddListener(TryMuteAudio);
    }

    private void OnDisable()
    {
        _videoAdShower.VideoShowed -= OnVideoShowed;
        _videoAdShower.VideoClosed -= OnVideoClosed;
        _button.onClick.RemoveListener(TryMuteAudio);
    }

    private void Start()
    {
        _currentImage = GetComponent<Image>();

        if (PlayerPrefs.GetInt("IsSoundOn", _isAudioOnInt) == 0)
        {
            MuteAudio();
        }
        else if(PlayerPrefs.GetInt("IsSoundOn", _isAudioOnInt) == 1)
        {
            UnmuteAudio();
        }
    }

    private void OnVideoShowed()
    {
        if (_isAudioOnInt == 0)
        {
            return;
        }
        else if(_isAudioOnInt == 1)
        {
            AudioListener.volume = 0;
        }
    }

    private void OnVideoClosed()
    {
        if(_isAudioOnInt == 0)
        {
            return;
        }
        else if (_isAudioOnInt == 1)
        {
            AudioListener.volume = 1;
        }
    }

    private void MuteAudio()
    {
        _isAudioOnInt = 0;
        _currentImage.sprite = _audioOff;
        AudioListener.volume = 0;
        PlayerPrefs.SetInt("IsSoundOn", _isAudioOnInt);
        PlayerPrefs.Save();
    }

    private void UnmuteAudio()
    {
        _isAudioOnInt = 1;
        _currentImage.sprite = _audioOn;
        AudioListener.volume = 1;
        PlayerPrefs.SetInt("IsSoundOn", _isAudioOnInt);
        PlayerPrefs.Save();
    }

    public void TryMuteAudio()
    {
        if (_isAudioOnInt == 1)
        {
            MuteAudio();
        }
        else if(_isAudioOnInt == 0)
        {
            UnmuteAudio();
        }
    }
}

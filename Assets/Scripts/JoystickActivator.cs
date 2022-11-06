using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickActivator : MonoBehaviour
{
    [SerializeField] private VideoAdShower _videoAdShower;

    private void OnEnable()
    {
        _videoAdShower.VideoShowed += OnVideoShowed;
    }

    private void OnDisable()
    {
        _videoAdShower.VideoShowed -= OnVideoShowed;
    }

    private void Start()
    {
        _videoAdShower.VideoShowed += OnVideoShowed;
    }

    private void OnVideoShowed()
    {
        gameObject.SetActive(true);
    }
}

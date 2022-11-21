using UnityEngine;

public class HomingBombSoundManager : MonoBehaviour
{
    private AudioSource _explosionSound;

    private void OnEnable()
    {
        HomingBomb.AnyDestroyed += OnAnyDestroyed;
    }

    private void OnDisable()
    {
        HomingBomb.AnyDestroyed -= OnAnyDestroyed;
    }

    private void Start()
    {
        _explosionSound = GetComponent<AudioSource>();
    }

    private void OnAnyDestroyed()
    {
        _explosionSound.PlayOneShot(_explosionSound.clip);
    }
}

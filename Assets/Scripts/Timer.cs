using UnityEngine;

public class Timer : MonoBehaviour
{
    private float _elapsedTime;

    public float ElapsedTime => _elapsedTime;

    private void Update()
    {
        _elapsedTime += Time.deltaTime;
    }

}

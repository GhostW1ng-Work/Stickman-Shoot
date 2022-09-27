using UnityEngine;

public class Cannon : MonoBehaviour
{
    [SerializeField] private float _timeToActivate;

    public float TimeToActivate => _timeToActivate;

    private void Update()
    {       
    }
}

using UnityEngine;

public class CannonActivator : MonoBehaviour
{
    [SerializeField] private Timer _timer;
    [SerializeField] private Cannon[] _cannons;

    private int _cannonIndex;

    private void Start()
    {
    }

    private void Update()
    {
        if(_cannonIndex < _cannons.Length)
        {
            if (_timer.ElapsedTime >= _cannons[_cannonIndex].TimeToActivate)
            {
                _cannons[_cannonIndex].gameObject.SetActive(true);
                _cannonIndex++;
            }
        }  
    }
}

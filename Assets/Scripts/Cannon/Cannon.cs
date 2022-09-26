using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    [SerializeField] private Timer _timer;
    [SerializeField] private float _timeToActivate;

    public float TimeToActivate => _timeToActivate;

    private void Update()
    {       
    }
}

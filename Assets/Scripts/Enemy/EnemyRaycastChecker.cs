using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRaycastChecker : MonoBehaviour
{
    [SerializeField] private Pointer _pointer;
    [SerializeField] private PlayerGunner _gunner;
    [SerializeField] private EnemyPointersHandler _handler;

    private void OnEnable()
    {
        _gunner.EnemyMissed += OnEnemyMissed;
    }

    private void OnDisable()
    {
        _gunner.EnemyMissed -= OnEnemyMissed;
    }

    private void OnEnemyMissed()
    {
        _pointer.gameObject.SetActive(false);
    }

    public void ActivatePointer()
    {
        if (_handler.PointerIsActive == false)
            _pointer.gameObject.SetActive(true);
    }
}

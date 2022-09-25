using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gunner : MonoBehaviour
{
    [SerializeField] private Camera _playerCamera;
    [SerializeField] private Collider _playerCollider;

    private Plane[] _planes;

    private void Start()
    {
        _planes = GeometryUtility.CalculateFrustumPlanes(_playerCamera);
    }

    private void Update()
    {
        if(GeometryUtility.TestPlanesAABB(_planes, _playerCollider.bounds))
        {
            Debug.Log("Jopa");
        }
    }
}

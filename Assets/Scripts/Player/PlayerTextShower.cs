using UnityEngine;

public class PlayerTextShower : MonoBehaviour
{
    [SerializeField] private Camera _camera;

    private void Update()
    {
        transform.LookAt(_camera.transform);
        transform.rotation = _camera.transform.rotation;
    }
}
 


using UnityEngine;

[RequireComponent(typeof(Animator))]
public class CannonAnimator : MonoBehaviour
{
    private Animator _animator;
    private ProjectileSpawner _spawner;

    private void Start()
    {
        
    }

    private void OnEnable()
    {
        _animator = GetComponent<Animator>();
        _spawner = transform.GetChild(0).GetComponent<ProjectileSpawner>();
        _spawner.ActivateCoroutineShoot(_animator);
        _spawner.ActivateCoroutineWait(_animator);
    }
}

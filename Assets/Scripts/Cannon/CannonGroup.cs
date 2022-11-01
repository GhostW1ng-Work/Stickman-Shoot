using UnityEngine;

public class CannonGroup : MonoBehaviour
{
    [SerializeField] private ProjectileSpawner[] _projectileSpawners;

    private void OnEnable()
    {
        foreach (ProjectileSpawner projectileSpawner in _projectileSpawners)
        {
            projectileSpawner.AnimationEnded += OnAnimationEnded;
        }
    }

    private void OnDisable()
    {
        foreach (ProjectileSpawner projectileSpawner in _projectileSpawners)
        {
            projectileSpawner.AnimationEnded -= OnAnimationEnded;
        }
    }

    private void OnAnimationEnded()
    {
        gameObject.SetActive(false);
    }
}

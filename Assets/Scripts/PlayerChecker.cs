using UnityEngine;
using UnityEngine.Events;

public class PlayerChecker : MonoBehaviour
{
    public event UnityAction PlayerFalled;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Player player))
        {
            PlayerFalled?.Invoke();
            player.gameObject.SetActive(false);
        }
    }
}

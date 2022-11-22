using UnityEngine;

public class BossRagdoll : MonoBehaviour
{
    [SerializeField] private Rigidbody[] _limbs;

    public void PushRagdoll(Transform pusherPosition, float pushPower)
    {
        var currentDirection = transform.position - pusherPosition.position;

        for (int i = 0; i < _limbs.Length; i++)
        {
            _limbs[i].AddForce(currentDirection * pushPower, ForceMode.Impulse);
        }
    }
}

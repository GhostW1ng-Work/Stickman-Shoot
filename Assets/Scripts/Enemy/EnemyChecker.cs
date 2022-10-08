using UnityEngine;

public class EnemyChecker : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out Nucleus nucleus))
        {
            Debug.Log("���� ������");
            var currentDirection = transform.position - nucleus.transform.position;
            transform.Translate(currentDirection * nucleus.Speed * Time.fixedDeltaTime);
        }
    }
}

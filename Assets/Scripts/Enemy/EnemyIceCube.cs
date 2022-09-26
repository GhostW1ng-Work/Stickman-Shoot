using UnityEngine;

public class EnemyIceCube : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out Nucleus nucleus))
        {
            Debug.Log("ядро попало");
            var currentDirection = transform.position - nucleus.transform.position;
            transform.Translate(currentDirection * nucleus.Speed * Time.fixedDeltaTime);
        }
    }
}

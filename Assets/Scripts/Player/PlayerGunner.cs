using UnityEngine;
using UnityEngine.Events;

public class PlayerGunner : MonoBehaviour
{
    public UnityAction EnemyHitted;
    public UnityAction EnemyMissed;

    private void Update()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        Debug.DrawRay(transform.position, transform.forward * 100, Color.yellow);

        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            Enemy enemy = hit.transform.GetComponent<Enemy>();
            enemy.ActivatePointer();
            EnemyHitted?.Invoke();

        }
        else
        {
            EnemyMissed?.Invoke();
        }
    }
}

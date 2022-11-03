using System.Collections;
using UnityEngine;

public class EnemyIceCube : MonoBehaviour
{
    [SerializeField] private EnemyChecker _parentObject;
    [SerializeField] private float _timeToDefrost;

    private void OnEnable()
    {
        StartCoroutine(ActivateDefrost());
    }

    private IEnumerator ActivateDefrost()
    {
        yield return new WaitForSeconds(_timeToDefrost);
        _parentObject.transform.position = transform.position;
        _parentObject.gameObject.SetActive(true);
        gameObject.SetActive(false);
    }
}

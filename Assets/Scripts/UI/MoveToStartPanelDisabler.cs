using UnityEngine;
using UnityEngine.Events;

public class MoveToStartPanelDisabler : MonoBehaviour
{
    private CanvasGroup _canvasGroup;
    private bool _isAnyKeyPressed;

    public event UnityAction AnyKeyPressed;

    private void Start()
    {
        _canvasGroup = GetComponent<CanvasGroup>();
        _canvasGroup.alpha = 1;
        _isAnyKeyPressed = false;
    }

    private void Update()
    {
        if (Input.anyKey)
        {
            if (_isAnyKeyPressed)
            {
                return;
            }
            else
            {
                _canvasGroup.alpha = 0;
                AnyKeyPressed?.Invoke();
                _isAnyKeyPressed = true;
            }
        }
    }
}

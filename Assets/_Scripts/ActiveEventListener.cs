using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Exposes the OnEnable/OnDisable events to the inspector.
/// </summary>
public class ActiveEventListener : MonoBehaviour
{
    [SerializeField] private UnityEvent _onEnable, _onDisable;
    private void OnEnable()
    {
        _onEnable?.Invoke();
    }
    private void OnDisable()
    {
        _onDisable?.Invoke();
    }
}
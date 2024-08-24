using UnityEngine;
using UnityEngine.Events;

namespace GAPROG3.Assets._Scripts.GAPROG3
{

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
}
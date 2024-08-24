using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace GAPROG3.Assets._Scripts.GAPROG3
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField] private EventSystem _eventSystem;
        public void SetFirstObject(GameObject firstObject)
        {
            _eventSystem.SetSelectedGameObject(firstObject);
        }
    }
}
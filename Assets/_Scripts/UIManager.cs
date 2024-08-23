using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIManager : MonoBehaviour
{
    [SerializeField] private EventSystem _eventSystem;
    public void SetFirstObject(GameObject firstObject)
    {
        _eventSystem.SetSelectedGameObject(firstObject);
    }
}

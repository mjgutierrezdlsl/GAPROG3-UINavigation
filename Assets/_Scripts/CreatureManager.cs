using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CreatureManager : MonoBehaviour
{
    [SerializeField] GameManager _gameManager;

    [Header("Spawning")]
    [SerializeField] private CreatureController[] _creaturePrefabs;
    [SerializeField] private float _spawnRange = 3;
    [SerializeField] private UnityEvent<CreatureController[]> _onCreatureSpawn;

    private List<CreatureController> _creatures = new();

    private int _selectionIndex;
    private int SelectionIndex
    {
        get => _selectionIndex;
        set
        {
            _selectionIndex = value;
            if (_selectionIndex < 0)
            {
                _selectionIndex = _creatures.Count - 1;
            }
            else if (_selectionIndex >= _creatures.Count)
            {
                _selectionIndex = 0;
            }
        }
    }
    private bool _isSelecting;

    public void SpawnCreatures()
    {

        for (int i = 0; i < _creaturePrefabs.Length; i++)
        {
            var prefab = _creaturePrefabs[i];
            var creature = Instantiate(prefab, Random.insideUnitCircle * _spawnRange, Quaternion.identity);
            _creatures.Add(creature);
        }
        _onCreatureSpawn?.Invoke(_creatures.ToArray());
    }

    public void ClearCreatures()
    {
        foreach (var creature in _creatures)
        {
            Destroy(creature.gameObject);
        }
        _creatures.Clear();
    }

    private void Update()
    {

        if (Input.GetKey(KeyCode.LeftShift))
        {
            if (Input.GetKeyDown(KeyCode.Tab))
            {
                _isSelecting = false;
                for (int i = 0; i < _creatures.Count; i++)
                {
                    var player = _creatures[i];
                    player.HideSelectIndicator();
                }
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Tab))
            {
                _isSelecting = !_isSelecting;

                // Ensures that the previous creature has been deselected
                for (int i = 0; i < _creatures.Count; i++)
                {
                    var player = _creatures[i];
                    player.DeselectCreature();
                }

                // Only ran when selection is toggled off
                if (!_isSelecting)
                {
                    for (int i = 0; i < _creatures.Count; i++)
                    {
                        var player = _creatures[i];
                        player.HideSelectIndicator();
                        if (i == SelectionIndex)
                        {
                            player.SelectCreature();
                        }
                    }
                }
            }
        }

        if (_isSelecting)
        {
            SelectPlayer(SelectionIndex);
            if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.D))
            {
                SelectionIndex++;
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S))
            {
                SelectionIndex--;
            }
        }
    }

    private void SelectPlayer(int index)
    {
        for (int i = 0; i < _creatures.Count; i++)
        {
            var player = _creatures[i];
            if (i != index)
            {
                player.HideSelectIndicator();
            }
            else
            {
                player.ShowSelectIndicator();
            }
        }
    }
}

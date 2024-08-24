using System.Collections.Generic;
using UnityEngine;
namespace AIGAME
{
    public class CharacterManager : MonoBehaviour
    {
        [SerializeField] Character[] _characterPrefabs;
        [SerializeField] Transform[] _wayPoints;
        private List<Character> _characters = new();
        private bool _isSelecting;
        private int _selectionIndex;
        private int SelectionIndex
        {
            get => _selectionIndex;
            set
            {
                _selectionIndex = value;
                if (_selectionIndex < 0)
                {
                    _selectionIndex = _characters.Count - 1;
                }
                else if (_selectionIndex >= _characters.Count)
                {
                    _selectionIndex = 0;
                }
            }
        }
        private void Start()
        {
            for (int i = 0; i < _characterPrefabs.Length; i++)
            {
                var character = Instantiate(_characterPrefabs[i], transform);
                character.transform.position = Random.insideUnitCircle * 3;
                if (character is NonPlayerCharacter nonPlayerCharacter)
                {
                    nonPlayerCharacter.Initialize(_wayPoints);
                }
                else
                {
                    character.Initialize();
                }
                _characters.Add(character);
            }
        }
        private void Update()
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    _isSelecting = false;
                    for (int i = 0; i < _characters.Count; i++)
                    {
                        var player = _characters[i];
                        player.HideSelectIndicator();
                    }
                }
            }
            else
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    _isSelecting = !_isSelecting;

                    // Ensures that the previous creature has been deselected
                    for (int i = 0; i < _characters.Count; i++)
                    {
                        var player = _characters[i];
                        // player.DeselectCreature();
                    }

                    // Only ran when selection is toggled off
                    if (!_isSelecting)
                    {
                        for (int i = 0; i < _characters.Count; i++)
                        {
                            var player = _characters[i];
                            player.HideSelectIndicator();
                            if (i == SelectionIndex)
                            {
                                player.Select();
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
            for (int i = _characters.Count - 1; i >= 0; i--)
            {
                var character = _characters[i];
                if (character == null)
                {
                    _characters.Remove(character);
                }
                if (i != index)
                {
                    character.HideSelectIndicator();
                }
                else
                {
                    character.ShowSelectIndicator();
                }
            }
        }
    }
}

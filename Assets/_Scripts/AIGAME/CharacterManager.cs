using System.Collections.Generic;
using UnityEngine;
namespace AIGAME
{
    public class CharacterManager : MonoBehaviour
    {
        [SerializeField] Character[] _characterPrefabs;
        [SerializeField] Transform[] _wayPoints;
        private List<Character> _characters = new();
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
            if (Input.GetKeyDown(KeyCode.Space))
            {
                for (int i = _characters.Count - 1; i >= 0; i--)
                {
                    var character = _characters[i];
                    if (character == null)
                    {
                        _characters.Remove(character);
                    }
                    else
                    {
                        character.Select();
                    }
                }
            }
        }
    }
}

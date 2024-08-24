using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GAPROG3.Assets._Scripts.GAPROG3
{
    public class PauseMenuController : MonoBehaviour
    {
        [SerializeField] Transform _contentRoot;
        [SerializeField] CreatureManager _creatureManager;
        [SerializeField] CreatureLikenessController _creatureLikenessPrefab;
        List<CreatureLikenessController> _displays = new();
        public void OnCreatureSpawn(CreatureController[] creatures)
        {
            ClearExistingDisplays();
            foreach (var creature in creatures)
            {
                var display = Instantiate(_creatureLikenessPrefab, _contentRoot);
                display.Init(creature);
                _displays.Add(display);
            }
        }

        private void ClearExistingDisplays()
        {
            foreach (var display in _displays)
            {
                Destroy(display.gameObject);
            }
            _displays.Clear();
        }
    }
}
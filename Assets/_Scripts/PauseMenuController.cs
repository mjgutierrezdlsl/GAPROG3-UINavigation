using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuController : MonoBehaviour
{
    [SerializeField] Transform _contentRoot;
    [SerializeField] CreatureManager _creatureManager;
    [SerializeField] CreatureLikenessController _creatureLikenessPrefab;
    public void OnCreatureSpawn(CreatureController[] creatures)
    {
        foreach (var creature in creatures)
        {
            var display = Instantiate(_creatureLikenessPrefab, _contentRoot);
            display.Init(creature);
        }
    }
}

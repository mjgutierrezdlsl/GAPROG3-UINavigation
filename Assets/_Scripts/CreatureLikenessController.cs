using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreatureLikenessController : MonoBehaviour
{
    [SerializeField] Image _creatureDisplay;
    [SerializeField] Slider _creatureLikeness;

    private CreatureController _creature;

    public void Init(CreatureController creature)
    {
        _creature = creature;
        _creatureDisplay.sprite = _creature.Sprite;
        _creatureLikeness.value = _creature.Likeness;
    }
    private void OnEnable()
    {
        _creatureLikeness.value = _creature.Likeness / _creature.MaxLikeness;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Skill Item", menuName = "ScriptableObjects/Items/Skill Item", order = 1)]
public class SkillItem : ScriptableItem
{
    [SerializeField] private DamageData _damageData;
    [SerializeField] private AudioClip _sound;

    public DamageData DamageData
    {
        get => _damageData;
        set => _damageData = value;
    }
    private void OnEnable()
    {
        _prefab = _prefab as DArrow;
    }
}

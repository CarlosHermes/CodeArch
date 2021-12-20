using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New PlayerWeaknesses", menuName = "ScriptableObjects/Player/Weaknesses")]
public class PlayerWeaknesses : ScriptableObject
{
    [SerializeField] private List<DamageData> _typeMultipliers;
    public List<DamageData> TypeMultipliers { get => _typeMultipliers; set => _typeMultipliers = value; }
}

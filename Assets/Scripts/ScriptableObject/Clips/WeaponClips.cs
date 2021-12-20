using System.Collections.Generic;
using Animancer;
using UnityEngine;

[CreateAssetMenu(fileName = "New Weapon Clips", menuName = "ScriptableObjects/Weapon Clips")]
public class WeaponClips : ScriptableObject
{
    [SerializeField] private ClipState.Transition _attackClip;
    [SerializeField] private List<AudioClip> _attackSounds;
    
    public ClipState.Transition AttackClip => _attackClip;
    public List<AudioClip> AttackSounds => _attackSounds;
}
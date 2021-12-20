using System.Collections;
using System.Collections.Generic;
using Animancer;
using UnityEngine;

[CreateAssetMenu(fileName = "New EnemyClips", menuName = "ScriptableObjects/Clips")]
public class ScriptableClips : ScriptableObject
{
    [SerializeField] private ClipState.Transition _iddleClip;
    [SerializeField] private ClipState.Transition _attackClip;
    [SerializeField] private ClipState.Transition _runClip;
    [SerializeField] private ClipState.Transition _dieClip;
    [SerializeField] private List<ClipState.Transition> _additional;

    public ClipState.Transition IddleClip { get => _iddleClip; set => _iddleClip = value; }
    public ClipState.Transition AttackClip { get => _attackClip; set => _attackClip = value; }
    public ClipState.Transition RunClip { get => _runClip; set => _runClip = value; }
    public ClipState.Transition DieClip { get => _dieClip; set => _dieClip = value; }
    public List<ClipState.Transition> Additional { get => _additional; set => _additional = value; }
}

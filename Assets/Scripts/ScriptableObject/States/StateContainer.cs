using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New StateContainer", menuName = "ScriptableObjects/StateContainer")]
public class StateContainer : ScriptableObject
{

        [SerializeField] public ScriptableState _iddleState;
        [SerializeField] public ScriptableState _attackState;
        [SerializeField] public ScriptableState _chaseState;
        [SerializeField] public ScriptableState _dieState;
        [SerializeField] public ScriptableState _patrolState;
        [SerializeField] public List<ScriptableState> _additional;

}

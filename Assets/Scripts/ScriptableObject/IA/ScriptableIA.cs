using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[ExecuteInEditMode]
[CreateAssetMenu (fileName = "New Patrol", menuName = "ScriptableObjects/Patrol")]
public class ScriptableIA : ScriptableObject
{
    [SerializeField] private List<Vector3> _positions;
    [SerializeField] private int _layer;
    [SerializeField] private int _i = 0;

    public int Layer { get => _layer; set => _layer = value; }
    public int I { get => _i; set => _i = value; }
    public List<Vector3> Positions { get => _positions; set => _positions = value; }
}

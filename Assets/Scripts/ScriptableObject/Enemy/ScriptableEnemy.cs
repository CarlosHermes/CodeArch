using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New Enemy", menuName = "ScriptableObjects/Enemy")]
public class ScriptableEnemy : ScriptableObject
{
    [SerializeField] private string _type;
    [SerializeField] private int _healthPoints;
    [SerializeField] private float _damage, _speed;
    [SerializeField] private List<DamageData> _typeMultipliers;
    [SerializeField] private AudioClip _detectPlayer; 
    [SerializeField] private int _exp;

    public string Type { get => _type; set => _type = value; }
    public int HealthPoints { get => _healthPoints; set => _healthPoints = value; }
    public float Damage { get => _damage; set => _damage = value; }
    public float Speed { get => _speed; set => _speed = value; }
    public List<DamageData> TypeMultipliers { get => _typeMultipliers; set => _typeMultipliers = value; }
    public AudioClip DetectPlayer { get => _detectPlayer; set => _detectPlayer = value; }
    public int Exp { get => _exp; set => _exp = value; }
}

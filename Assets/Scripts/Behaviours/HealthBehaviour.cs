using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class HealthBehaviour : MonoBehaviour, IHittable
{
    [SerializeField] protected FloatVariable _health;
    [SerializeField] protected float _maxHealth;
    public abstract void GetHit(DamageData damageData);
}

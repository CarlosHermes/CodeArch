using System;
using UnityEngine;
using System.Collections.Generic;

public class PlayerHealth : HealthBehaviour
{
    [SerializeField] private PlayerWeaknesses _playerWeaknesses;

    public override void GetHit(DamageData damageData)
    {
        //float multiplier = _playerWeaknesses.TypeMultipliers.Find(d => d.elementalType == damageData.elementalType).damage;
        float damage = damageData.damage;// * multiplier;
        float health = _health.Value - damageData.damage;
        if (health <= 0) _health.Value = 0;
        else _health.Value = health;
        if (Application.platform == RuntimePlatform.Android)
            Handheld.Vibrate();
    }
}
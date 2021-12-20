using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeWeapon : HitBehaviour
{
    private Enemy _enemy;

    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _audioSource.clip = _audioClip;
        _enemy = transform.root.GetComponent<Enemy>();
        _damageData = new DamageData(_enemy.ScriptableEnemy.Damage, _damageData.elementalType);
    }
    private void OnTriggerEnter(Collider collider)
    {
        if(collider.CompareTag("Player") && collider.TryGetComponent<IHittable>(out var hitable))
        {
            hitable.GetHit(_damageData);
            _audioSource.Play();
        }
    }

}

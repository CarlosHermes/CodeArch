using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBehaviour : MonoBehaviour
{
    [SerializeField] protected DamageData _damageData;
    [SerializeField] protected AudioSource _audioSource;
    [SerializeField] protected AudioClip _audioClip;
    protected virtual void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<IHittable>(out IHittable target))
        {
            _audioSource.Play();
            target.GetHit(_damageData);
        }
    }
}
public interface IHitter
{
    DamageData DamageData { get;  set; }
    void OnTriggerEnter(Collider other);
}
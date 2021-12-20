using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaspMale : Enemy, IHittable
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _getHit;
    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
        _audioSource.clip = _getHit;
        _audioSource.volume = 0.3f;
        base.Awake();
    }

    public void GetHit(DamageData damageData)
    {

        _audioSource.Play();
        base.GetHit(damageData);
    }
    public override void DetectPlayer(Transform player)
    {
        _focus = player;
        StateMachine.TryChangeState(Vector3.Distance(_focus.transform.position, transform.position) < _attackDistance ?
        StateContainer._attackState : StateContainer._chaseState);
    }
    private void OnEnable()
    {
        WaspFem.Detect += DetectPlayer;
    }
    private void OnDisable()
    {
        WaspFem.Detect -= DetectPlayer;
    }
}

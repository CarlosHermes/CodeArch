using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class WaspFem : Enemy, IHittable
{
    private bool detected = false;
    public static event Action<Transform> Detect = delegate { };
    [SerializeField] private AudioSource _audioSource;
    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
        base.Awake();
    }

    public void GetHit(DamageData damageData)
    {
        base.GetHit(damageData);
    }
    public override void DetectPlayer(Transform player)
    {
        if(!detected)
        {
            _focus = player;
            StateMachine.TryChangeState(StateContainer._additional[0]);
            Debug.Log("señalando");
            detected = true;
        }
    }
    public void SendCommand()
    {
        Debug.Log("señalado");
        _audioSource.clip = _scriptableEnemy.DetectPlayer;
        _audioSource.Play();
        Detect.Invoke(_focus);      
    }
}


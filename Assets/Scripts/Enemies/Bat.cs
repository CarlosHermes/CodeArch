using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class Bat : Enemy
{
    [SerializeField] Throwable _attack;
    [SerializeField] Transform _shotPoint;
    private StackManager _sm;
    private AudioSource _audioSource;
    private void Awake()
    {
        base.Awake();
        _sm = StackManager.Instance;
        _audioSource = GetComponent<AudioSource>();
    }
    public void Shoot() //animator del murcielago
    {
        Throwable projectile;
        try {  
            projectile = _sm.Peek();
            _sm.Pop(_shotPoint.position);
        }
        catch
        {
            projectile = Instantiate(_attack, _shotPoint);
            projectile.transform.position = _shotPoint.position;
        }
        SludgeBomb projct = (SludgeBomb)projectile;
        projct.Go1 = _shotPoint;
        //projectile._stacker = this;
        projct.Enemy = this;
        projct.Focus = Focus;
        projct.transform.position = _shotPoint.position;
        projct.GetStarted();
    }
    
    public void Die()
    {
        GetComponent<CapsuleCollider>().enabled = true;
        _audioSource.clip = ScriptableEnemy.DetectPlayer;
        _audioSource.Play();
        base.Die();
    }

}

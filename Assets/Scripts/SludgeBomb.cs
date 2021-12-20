using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Animancer;

public class SludgeBomb : Throwable, IHitter
{
    private Transform _focus;
    private AnimancerComponent _animancer;
    [SerializeField] private AnimationClip grow;
    [SerializeField] private AnimationClip spin;
    private StackManager _sm;
    private DamageData _damageData;
    private Enemy _enemy;
    private Transform go1;
    //public IStacker _stacker { get => _stacker; set { } }
    public Transform Focus { get => _focus; set => _focus = value; }
    public Transform Go1 { get => go1; set => go1 = value; }
    public Enemy Enemy { get => _enemy; set => _enemy = value; }
    public DamageData DamageData { get => _damageData; set => _damageData = value; }

    [SerializeField] float maxHeight, timeToHit;
    private Rigidbody _rb;
    private Vector3 originalPos;
    private float timePassed;

    private float vx, vz, ymax;
    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        _animancer = GetComponent<AnimancerComponent>();
        _sm = StackManager.Instance;
    }
    public void GetStarted()
    {
        _animancer.Play(grow);
        timePassed = Time.time;
        vx = (_focus.position.x - Go1.position.x) / timeToHit;
        vz = (_focus.position.z - Go1.position.z) / timeToHit;
        ymax = maxHeight - _focus.position.y;
        originalPos = Go1.transform.position;
    }
    public void Shoot()
    {
        _animancer.Play(spin);
        transform.parent = null;
        _rb.useGravity = true;
        _rb.velocity = new Vector3(vx, 4 * (ymax - originalPos.y) / timeToHit, vz);
        _damageData = new DamageData(_enemy.ScriptableEnemy.Damage, ElementalType.Poison);
    }

    public void OnTriggerEnter(Collider other)
    {        
        if (other.TryGetComponent<IHittable>(out IHittable target))
        {
            target.GetHit(_damageData);
        }/*
        if (other)
        {
            IHittable target = other.GetComponent<PlayerHealth>();
            target.GetHit(_damageData);
        }
        */
        //target.GetHit(_damageData);

        Debug.Log("hit");
        _rb.velocity = new Vector3(0, 0, 0);
        _rb.useGravity = false;
        _sm.Push(this);
    }
}

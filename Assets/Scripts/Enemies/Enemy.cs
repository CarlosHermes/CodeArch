using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Animancer;

public abstract class Enemy : MonoBehaviour, IHittable
{
    [SerializeField] private ScriptableClips _scriptableClips;
    [SerializeField] protected ScriptableEnemy _scriptableEnemy;
    [SerializeField] protected Transform _focus;
    [SerializeField] public float _attackDistance;
    [SerializeField] protected ScriptableIA iA;
    [SerializeField] protected StateContainer _stateContainer;
    [SerializeField] protected int _state;
    [SerializeField] protected ScriptableState _defaultState;
    [SerializeField] protected IntVariable _exp;
    protected AnimancerComponent _animancer;
    [SerializeField] protected int _currentHP;
    protected int _destinationPoint;
    protected NavMeshAgent _agent;
    protected FiniteStateMachine<ScriptableState> _stateMachine;

    public StateContainer StateContainer { get => _stateContainer; set => _stateContainer = StateContainer; }
    public int CurrentHP { get => _currentHP; set => _currentHP = value; }
    public ScriptableEnemy ScriptableEnemy { get => _scriptableEnemy; set => _scriptableEnemy = value; }
    public NavMeshAgent Agent { get => _agent; set => _agent = value; }
    public int State { get => _state; set => _state = value; }
    public ScriptableIA IA { get => iA; set => iA = value; }

    public int DestinationPoint { get => _destinationPoint; set => _destinationPoint = value; }

    public Transform Focus { get => _focus; set => _focus = value; }
    public AnimancerComponent Animancer { get => _animancer; set => _animancer = value; }
    public ScriptableClips ScriptableClips { get => _scriptableClips; set => _scriptableClips = value; }

    public FiniteStateMachine<ScriptableState> StateMachine => _stateMachine;

    protected void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
        _animancer = GetComponent<AnimancerComponent>();
        _stateMachine = new FiniteStateMachine<ScriptableState>(this, _defaultState);
    }
    protected void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Focus = other.transform;
            DetectPlayer(Focus);
        }
    }
    public void GetHit(DamageData damageData)
    {
        //float multiplier = _scriptableEnemy.TypeMultipliers.Find(d => d.elementalType == damageData.elementalType).damage;
        float damage = damageData.damage;// * multiplier;
        _currentHP -= (int)damage; //tipos
        if (_currentHP <= 0)
            StateMachine.TryChangeState(StateContainer._dieState);
        else
            StateMachine.TryChangeState(Vector3.Distance(Focus.transform.position, transform.position) < _attackDistance ?
                StateContainer._attackState : StateContainer._chaseState);
    }
    protected void Start()
    {
        _currentHP = ScriptableEnemy.HealthPoints;
        ForceDefaultState();
    }

    protected void Update()
    {
        _stateMachine.CurrentState.OnUpdateState(this);
    }
    public abstract void DetectPlayer(Transform player);

    public void EndShoot()
    {
        StateMachine.TryChangeState(Vector3.Distance(Focus.transform.position, transform.position) < _attackDistance ?
            StateContainer._attackState : StateContainer._chaseState);
    }

    public void ForceDefaultState()
    {
        _stateMachine.ForceChangeState(_defaultState);
    }
    public void Die()
    {
        _exp.Value += _scriptableEnemy.Exp;
        StartCoroutine(FadeDie());
    }
    private IEnumerator FadeDie()
    {
        if (!gameObject.GetComponent<Rigidbody>())
            this.gameObject.AddComponent<Rigidbody>();
        _agent.enabled = false;
        yield return new WaitForSeconds(3f);
        gameObject.SetActive(false);
    }
}

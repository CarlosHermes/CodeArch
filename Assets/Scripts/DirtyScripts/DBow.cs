using System;
using System.Collections.Generic;
using Animancer;
using Cinemachine;
using UnityEngine;

public class DBow : DWeapon
{
    public static SkillItem ActiveSkill;
    [SerializeField] private SkillItem _activeSkill;
    [SerializeField] private int _queueCapacity;
    [SerializeField] private CinemachineVirtualCamera _povCam;
    [SerializeField] private DArrow _arrowPrefab;
    [SerializeField] private Transform _stringPoint;
    [SerializeField] private Transform _arrowHand;

    [SerializeField] private float _impulse = 15f;
    private DArrow _currentArrow;
    private Queue<DArrow> _carcajQueue;

    private void Awake()
    {
        _animancer = GetComponent<AnimancerComponent>();
    }
    
    private void Start()
    {
        _carcajQueue = new Queue<DArrow>();
        for (int i = 0; i < _queueCapacity; i++)
        {
            var arrow = Instantiate(_arrowPrefab, _arrowHand);
            arrow.Owner = this;
            _carcajQueue.Enqueue(arrow);
            arrow.gameObject.SetActive(false);
        }

        ActiveSkill = _activeSkill;
        LoadArrow();
    }

    public void Shoot() => _currentArrow.Impulse(_impulse, ActiveSkill);

    public void TryVibrate()
    {
        if (Application.platform == RuntimePlatform.Android)
            Handheld.Vibrate();
    }

    public void LoadArrow()
    {
        _currentArrow = _carcajQueue.Dequeue();
        _currentArrow.gameObject.SetActive(true);
        _currentArrow.transform.SetPositionAndRotation(_arrowHand.position, _arrowHand.rotation);
        //_currentArrow.transform.position = _arrowHand.position;
        //_currentArrow.transform.rotation = _arrowHand.rotation;
    }
    
    public void GetBackArrow(DArrow arrow)
    {
        _carcajQueue.Enqueue(arrow);
        arrow.transform.SetParent(_arrowHand);
        arrow.gameObject.SetActive(false);
    }

    public override void ReleaseAttack()
    {
        //if (_state.NormalizedTime < 0.2f || _state.NormalizedTime > 0.5f)
          //  _impulse = 2f;
    }
}

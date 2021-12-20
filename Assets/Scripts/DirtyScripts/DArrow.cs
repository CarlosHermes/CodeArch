using System;
using System.Collections;
using UnityEngine;

public class DArrow : MonoBehaviour
{
    [SerializeField] private SkillItem _skillItem;
    [SerializeField] private DBow _owner;
    private Rigidbody _rb;
    private BoxCollider _collider;
    
    public Rigidbody Rb
    {
        get => _rb;
    }

    [SerializeField] private float _returnTime;
    
    public SkillItem SkillItem
    {
        get => _skillItem;
        set => _skillItem = value;
    }

    public DBow Owner
    {
        get => _owner;
        set => _owner = value;
    }

    void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        _rb.useGravity = false;
        _rb.isKinematic = true;
        _collider = GetComponent<BoxCollider>();
        _collider.enabled = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.CompareTag("Player") && other is BoxCollider box)
        {
            if (box.TryGetComponent<IHittable>(out var hit))
            {
                hit.GetHit(_skillItem.DamageData);
                _rb.useGravity = false;
                _rb.velocity = new Vector3(0, 0, 0);
                transform.SetParent(other.transform);
                _collider.enabled = false;
                _rb.isKinematic = true;
            }
        }
    }

    public IEnumerator ReturnTime()
    {
        yield return new WaitForSeconds(_returnTime);
        _owner.GetBackArrow(this);
    }

    private void FixedUpdate()
    {
        if (_rb.useGravity)
            transform.LookAt(this.transform.position + _rb.velocity);
    }

    public void Impulse(float force, SkillItem skill)
    {
        _skillItem = skill;
        transform.SetParent(null);
        _rb.isKinematic = false;
        _rb.velocity = Vector3.zero;
        _rb.useGravity = true;
        _rb.AddForce(transform.forward*force, ForceMode.Impulse);
        _collider.enabled = true;
        StartCoroutine(ReturnTime());
        _skillItem.Amount -= 1;
    }
}
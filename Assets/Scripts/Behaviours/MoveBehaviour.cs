using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof (Rigidbody))]
public class MoveBehaviour : MonoBehaviour
{
    [SerializeField] private float _speed;
    public float Speed { get; set; }

    private Rigidbody _rb;
    public void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    public void MoveForward()
    {
        _rb.velocity = transform.forward * _speed;
    }
    
    public void MoveForward(Vector2 inputDir)
    {
        var trans = transform;
        _rb.velocity = (trans.forward * (inputDir.y * _speed)) + (trans.right * (inputDir.x * _speed) + (trans.up * _rb.velocity.y));
    }
    

    public void Move(Vector3 newDir)
    {
        _rb.MovePosition((transform.position + newDir) * _speed);
    }

    public void Move(Vector2 inputDir)
    {
        var trans = transform;
        Vector3 input = (trans.forward * (inputDir.y * _speed)) + (trans.right * (inputDir.x * _speed) + (trans.up * _rb.velocity.y));
        transform.Translate(input * Time.deltaTime, Space.World);
    }
}

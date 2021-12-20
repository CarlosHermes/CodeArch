using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StackManager : MonoBehaviour
{
    private StackBehaviour _sb;

    public static StackManager Instance;
    void Awake()
    {
        _sb = GetComponent<StackBehaviour>();
        if (Instance == null) Instance = this;
    }
    public void Push(Throwable go)
    {
        go.gameObject.SetActive(false);
        _sb.Push(go);
    }
    public void Pop(Vector3 originalPos)
    {
        _sb.Pop(originalPos);
    }
    public Throwable Peek()
    {
        return _sb.Peek();
    }
}

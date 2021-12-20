using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StackBehaviour : MonoBehaviour
{
    public Stack<Throwable> GameObjList;

    [SerializeField] private List<Throwable> _sludgeBombs;
    void Awake()
    {
        GameObjList = new Stack<Throwable>();
        foreach (Throwable thr in _sludgeBombs)
            Push(thr);
    }
    public void Push(Throwable go)
    {
        GameObjList.Push(go);
    }
    public void Pop(Vector3 originalPos)
    {
        Throwable peek = GameObjList.Peek();
        peek.gameObject.SetActive(true);
        peek.transform.position = originalPos;
        GameObjList.Pop();
    }
    public Throwable Peek()
    {
        return (GameObjList.Peek());
    }
}

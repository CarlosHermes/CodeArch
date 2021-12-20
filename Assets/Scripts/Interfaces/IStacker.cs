using System.Collections.Generic;
using UnityEngine;
public interface IStacker
{
    Stack<Throwable> _stack { get; set; }
    void Pop();//needed?
    void Push(Throwable stackeable);
    Throwable Peek();//needed?
}

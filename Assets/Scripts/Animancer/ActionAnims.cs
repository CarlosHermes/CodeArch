
using UnityEngine;
using Animancer;
//[CreateAssetMenu(fileName = "New ActionAnim", menuName = "ScriptableObjects/ActionAnim")]
public abstract class ActionAnims: MonoBehaviour //: ScriptableObject
{
    [SerializeField] protected AnimationClip _animation;
    protected AnimancerComponent _animancer;
    protected AnimancerState state;

    private void Start()
    {
        _animancer = GetComponent<AnimancerComponent>();
        state = _animancer.Play(_animation);
        state.Speed = 0;
    }
    public void Open()
    {
        state.Speed = 1;
    }
    public void Close()
    {
        state.Speed = -1;
    }
    public void Stay()
    {
        state.Speed = 0;
    }
    /*private void Update()
    {
        if (Time.time % 3 > 0 && Time.time % 3 < 0.3f)
            Open();
        if (Time.time % 5 > 0 && Time.time % 5 < 0.3f)
            Close();
    }*/
}

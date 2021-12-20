using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(SUnityEvent))]
public class SUnityEventEditor : UnityEditor.Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        
        var uEvent = (SUnityEvent)target;
        if(GUILayout.Button("Invoke Event", GUILayout.Height(40)))
        {
            uEvent.Invoke();
        }
    }
}

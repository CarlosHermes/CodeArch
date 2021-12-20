using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEditor;

public class TransformTaker : EditorWindow
{
    ScriptableIA transformCatcher;
    //GameObject prefab;
    [MenuItem ("Window/PathGenerator")]
    static void Init()
    {
        TransformTaker window = (TransformTaker)EditorWindow.GetWindow (typeof(TransformTaker));
        window.Show();
    }
    public void OnGUI()
    {
        transformCatcher = (ScriptableIA)EditorGUILayout.ObjectField (transformCatcher, typeof(ScriptableIA), true);
        //prefab = (GameObject)EditorGUILayout.ObjectField(prefab, typeof(GameObject), true);
    }
    void CustomUpdate (UnityEditor.SceneView sv)
    {
        Event e = Event.current;
        if (e.type == EventType.KeyDown && e.keyCode==KeyCode.V && transformCatcher.I < transformCatcher.Positions.Count)
        {
            Vector3 mousePosition = new Vector3(e.mousePosition.x, Camera.current.pixelHeight - e.mousePosition.y, 0);
            RaycastHit hit;
            if (Physics.Raycast(Camera.current.ScreenPointToRay(mousePosition), out hit, Mathf.Infinity, ~LayerMask.NameToLayer("Ground"))){
                transformCatcher.Positions[transformCatcher.I++] = hit.point;
                //Instantiate(prefab, hit.point, Quaternion.identity);
            }
        }
    }
    void OnEnable()
    {
        SceneView.duringSceneGui -= CustomUpdate;
        SceneView.duringSceneGui += CustomUpdate;
    }
}

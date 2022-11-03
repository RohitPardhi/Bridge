using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine.UIElements;

[CustomEditor(typeof(Bridge))]
public class BridgeEditor : Editor
{
    Bridge targetBridge;      

    private void OnEnable()
    {
        targetBridge = (Bridge)target;

        targetBridge.Initialize();
    }

    public override void OnInspectorGUI()
    {                
        DrawDefaultInspector();
        if (GUILayout.Button("Save"))
        {
            targetBridge.SaveData();
        }        
    }


}

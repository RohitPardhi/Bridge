using UnityEditor;
using UnityEngine;

public class BridgeMenu
{    
    [MenuItem("Tools/Create Bridge Manager")]
    static void Create()
    {
        GameObject obj = new GameObject("Bridge Manager");
        obj.AddComponent<Bridge>();
    }

}

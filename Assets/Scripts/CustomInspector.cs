using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(LevelCreator))]
public class CustomInspector : Editor
{
    public override void OnInspectorGUI()
    {
        LevelCreator creator = (LevelCreator)target;

        if (GUILayout.Button("Create New Level"))
            creator.CreateNewScene();
    }
}

using System.Collections;
using System.IO;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;


public class LevelCreator : MonoBehaviour
{
    public GameObject levelPrefab;
    public void CreateNewScene()
    {   
        //Create New Scene
        var newScene = EditorSceneManager.NewScene(NewSceneSetup.EmptyScene, NewSceneMode.Single);
        //Level Number
        int levelNumber = EditorSceneManager.sceneCountInBuildSettings + 1;
        newScene.name = "Level" + levelNumber;
        //Fill New Scene with Level prefab
        Instantiate(levelPrefab);
        //Save 
        string path = Directory.GetCurrentDirectory() + "/Assets/Scenes/"+newScene.name+".unity";
        EditorSceneManager.SaveScene(EditorSceneManager.GetActiveScene(), path);
        Debug.Log("Level successfully created and saved into "+path);
        //Add new scene to build index
        var original = EditorBuildSettings.scenes;
        var newSettings = new EditorBuildSettingsScene[original.Length + 1];
        System.Array.Copy(original, newSettings, original.Length);
        var sceneToAdd = new EditorBuildSettingsScene("Assets/Scenes/"+newScene.name + ".unity", true);
        newSettings[newSettings.Length - 1] = sceneToAdd;
        EditorBuildSettings.scenes = newSettings;
    }
}
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor.SceneManagement;
using UnityEngine;


public class LevelCreator : MonoBehaviour
{
    public GameObject levelPrefab;
    public static int sceneCountInBuildSettings;
    private int levelNumber = sceneCountInBuildSettings + 3;
    public void CreateNewScene()
    {   //Create New Scene
        var newScene = EditorSceneManager.NewScene(NewSceneSetup.EmptyScene, NewSceneMode.Single);
        newScene.name = "Level" + levelNumber;
        //Fill New Scene with Level prefab
        Instantiate(levelPrefab);
        //Save path
        string path = Directory.GetCurrentDirectory() + "/Assets/Scenes/"+newScene.name+".unity";
        //Save
        EditorSceneManager.SaveScene(EditorSceneManager.GetActiveScene(), path);
        Debug.Log("Level successfully created and saved into "+path);

    }
}
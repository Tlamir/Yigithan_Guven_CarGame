using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor.SceneManagement;
using UnityEngine;


public class LevelCreator : MonoBehaviour
{
    public GameObject levelPrefab;
    public void CreateNewScene()
    {   //Create New Scene
        var newScene = EditorSceneManager.NewScene(NewSceneSetup.EmptyScene, NewSceneMode.Single);
        //Level Number
        int levelNumber = EditorSceneManager.sceneCountInBuildSettings + 1;
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
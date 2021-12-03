using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour 
{
    Spawner spawner;
    private void Start()
    {
        spawner = GameObject.FindGameObjectWithTag("Spawner").GetComponent<Spawner>();


    }
    void Update()
    {
        if (spawner.carNumber > 8)
        {
            //Load next level
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }



    
}

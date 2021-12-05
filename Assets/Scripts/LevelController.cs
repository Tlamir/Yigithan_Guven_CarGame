using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour 
{
    Spawner spawner;
    public GameObject[] cars;
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

   public void ResetGame()
   {
        //Reset game 
        int i = 0;
        cars = GameObject.FindGameObjectsWithTag("Car");
        foreach (GameObject car in cars)
        {
            car.transform.position = spawner.CarSpawnLocations[i];
            car.transform.rotation = spawner.CarSpawnRotations[i];
            i++;
            if (spawner.carNumber == i)
            {
                car.GetComponent<CarController>().isControlleble = true;
                car.GetComponent<CarController>().isFreezed = true;
                //Fix rotation later
            }
        }
   }
}

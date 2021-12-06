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
            LoadNewLevel();
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
            car.GetComponent<CarController>().isFreezed = true;
            car.GetComponent<CarController>().index = 0;
            i++;
            if (spawner.carNumber == i)
            {
                car.GetComponent<CarController>().isControlleble = true;
                car.GetComponent<Car>().ClearRecord();
            }

        }
    }

    void LoadNewLevel()
    {
        if (SceneManager.sceneCountInBuildSettings != SceneManager.GetActiveScene().buildIndex + 1)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}

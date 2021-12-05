using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject Car;            
    public GameObject Exit;

    public Vector3[] CarSpawnLocations = new Vector3[8];
    public Vector3[] ExitSpawnLocations = new Vector3[8];
    public Quaternion[] CarSpawnRotations = new Quaternion[8];

    public int carNumber = 0;

    private void Start()
    {
        carNumber = 0;
        SpawnCar(carNumber);
        SpawnExit(carNumber);
    }

    public void SpawnCar(int carNumberr)
    {
            for (int i = 0; i <= carNumberr; i++)
            {
                if (carNumberr == 8)
                { 
                 carNumber++;
                 break;
                }
                if (i == carNumberr)
                {
                 GameObject car = Instantiate(Car, CarSpawnLocations[i], Quaternion.identity);
                 car.GetComponent<CarController>().isControlleble = true;
                }
                else
                {
                GameObject car = Instantiate(Car, CarSpawnLocations[i], Quaternion.identity);
                car.GetComponent<CarController>().isControlleble = false;
                }              
            }
        carNumber++;
    }

    public void SpawnExit(int exitNumber)
    {  //-1 because start function increases value before instantiate a exit object
        if (exitNumber<9)
        {
            Instantiate(Exit, ExitSpawnLocations[exitNumber - 1], Quaternion.identity);
        } 
    }
}

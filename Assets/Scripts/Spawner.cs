using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public int carNumber = 2;
    public GameObject Car;
    public GameObject Exit;


    public Vector3[] CarSpawnLocations = new Vector3[8];
    public Vector3[] ExitSpawnLocations = new Vector3[8];

    public void SpawnCar(int carNumber)
    {
            for (int i = 0; i < carNumber; i++)
            {
                Instantiate(Car, CarSpawnLocations[i], Quaternion.identity);
            }     
    }

    public void SpawnExit(int exitNumber)
    {  
         Instantiate(Exit, ExitSpawnLocations[exitNumber], Quaternion.identity); 
    }
}

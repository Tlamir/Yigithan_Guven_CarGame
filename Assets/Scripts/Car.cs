using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    Spawner spawner;
    public GameObject[] cars;





    private void Start()
    {
        spawner=GameObject.FindGameObjectWithTag("Spawner").GetComponent<Spawner>();
         
    }
    //Upon collision with another GameObject
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Exit"))
        {
            //Debug.Log(spawner.carNumber);
            spawner.SpawnCar(spawner.carNumber);
            spawner.SpawnExit(spawner.carNumber);
        }

        if (other.gameObject.CompareTag("Building"))
        {
            //Reset game if car collides with building
            int i = 0;
            cars = GameObject.FindGameObjectsWithTag("Car");
            foreach (GameObject car in cars)
            {
                car.transform.position = spawner.CarSpawnLocations[i];    
                i++;
                if (spawner.carNumber==i)
                {
                    car.GetComponent<CarController>().isControlleble = true;
                    car.GetComponent<CarController>().isFreezed = true;
                    //Fix rotation later
                }
            }
            
        }
    }
}

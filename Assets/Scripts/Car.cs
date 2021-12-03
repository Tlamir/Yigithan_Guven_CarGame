using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    public bool isRecorded=false;
    Spawner spawner;
    public GameObject[] cars;
    private List<ActionReplayRecord> actionReplayRecords = new List<ActionReplayRecord>();





    private void Start()
    {
        spawner=GameObject.FindGameObjectWithTag("Spawner").GetComponent<Spawner>();
         
    }


    private void FixedUpdate()
    {
        if (!isRecorded && !this.GetComponent<CarController>().isFreezed)
        {
            actionReplayRecords.Add(new ActionReplayRecord { Position = transform.position, Rotation = transform.rotation });
           // Debug.Log("Now recording in car.cs");
        }
        
    }

    private void Update()
    {
        //Reset out of bounds
        if (this.transform.position.z>3.05 || this.transform.position.z < -3.05 || this.transform.position.x < -5.5 || this.transform.position.x > 5.5)
        {
            ResetGame();
        }
    }



    //Upon collision with another GameObject
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Exit"))
        {
            isRecorded=true;
            //Save records to some place 

            //Debug.Log(spawner.carNumber);
            spawner.SpawnCar(spawner.carNumber);
            spawner.SpawnExit(spawner.carNumber);

        }

        if (other.gameObject.CompareTag("Building"))
        {
            ResetGame();
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Car"))
        {
            ResetGame();
        }
    }

    void ResetGame()
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

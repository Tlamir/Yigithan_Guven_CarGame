using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    Spawner spawner;
    LevelController levelController;
    CarRecord CarRecord;

    
    //private List<ActionReplayRecord> actionReplayRecords = new List<ActionReplayRecord>();

    private void Start()
    {
        spawner=GameObject.FindGameObjectWithTag("Spawner").GetComponent<Spawner>();
        levelController=GameObject.FindGameObjectWithTag("LevelController").GetComponent<LevelController>();
        CarRecord = GameObject.FindGameObjectWithTag("CarRecord").GetComponent<CarRecord>();

        //Change car color if its controlleble
        if (this.GetComponent<CarController>().isControlleble)
        {
            this.GetComponent<Renderer>().material.color = Color.blue;
        }
    }


    private void Update()
    {
        //Reset out of bounds
        if (this.transform.position.z>3.05 || this.transform.position.z < -3.05 || this.transform.position.x < -5.5 || this.transform.position.x > 5.5)
        {
            levelController.ResetGame();
        }

        if (this.GetComponent<CarController>().isControlleble && !this.GetComponent<CarController>().isFreezed)
        {
            CarRecord.ActionReplayRecords[spawner.carNumber - 1].Add(new ActionReplayRecord { Position = transform.position, Rotation = transform.rotation });
        }
    }


    //Upon collision with another GameObject
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Exit"))
        {
            //Save records to some place 

            //Debug.Log(spawner.carNumber);
            spawner.SpawnCar(spawner.carNumber);
            spawner.SpawnExit(spawner.carNumber);

        }

        if (other.gameObject.CompareTag("Building"))
        {
            levelController.ResetGame();
            if (this.GetComponent<CarController>().isControlleble)
            {
                ClearRecord();
            }

        }
    }

    //OnColisionEnter --> cars are not trigger
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Car"))
        {
            levelController.ResetGame();
            if (this.GetComponent<CarController>().isControlleble)
            {
                ClearRecord();
            }
            
        }
    }

    private void ClearRecord()
    {
        CarRecord.ActionReplayRecords[this.GetComponent<CarController>().carNumber].Clear();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    Spawner spawner;
    LevelController levelController;

    
    public bool isRecorded=false;
    private List<ActionReplayRecord> actionReplayRecords = new List<ActionReplayRecord>();

    private void Start()
    {
        spawner=GameObject.FindGameObjectWithTag("Spawner").GetComponent<Spawner>();
        levelController=GameObject.FindGameObjectWithTag("LevelController").GetComponent<LevelController>();

        //Change car color if its controlleble
        if (this.GetComponent<CarController>().isControlleble)
        {
            this.GetComponent<Renderer>().material.color = Color.blue;
        }
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
            levelController.ResetGame();
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
            levelController.ResetGame();
        }

    }

    //OnColisionEnter --> cars are not trigger
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Car"))
        {
            levelController.ResetGame();
        }
    }
}

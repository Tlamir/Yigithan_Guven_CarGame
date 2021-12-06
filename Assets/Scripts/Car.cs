using UnityEngine;

public class Car : MonoBehaviour
{
    Spawner spawner;
    LevelController levelController;
    CarRecord CarRecord;

    private void Start()
    {
        spawner = GameObject.FindGameObjectWithTag("Spawner").GetComponent<Spawner>();
        levelController = GameObject.FindGameObjectWithTag("LevelController").GetComponent<LevelController>();
        CarRecord = GameObject.FindGameObjectWithTag("CarRecord").GetComponent<CarRecord>();

        //Change car color if its controlleble
        if (this.GetComponent<CarController>().isControlleble)
            this.GetComponent<Renderer>().material.color = Color.blue;
    }


    private void Update()
    {
        //Reset out of bounds
        if (this.transform.position.z > 3.05 || this.transform.position.z < -3.05 || this.transform.position.x < -5.5 || this.transform.position.x > 5.5)
            levelController.ResetGame();
 
        //Record Movment
        if (this.GetComponent<CarController>().isControlleble && !this.GetComponent<CarController>().isFreezed && spawner.carNumber < 8)
            Record();
    }


    //Upon collision with another GameObject
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Exit") && (this.GetComponent<CarController>().isControlleble))
        {
            spawner.SpawnCar(spawner.carNumber);
            spawner.SpawnExit(spawner.carNumber);
        }

        if (other.gameObject.CompareTag("Building"))
        {
            levelController.ResetGame();
            if (this.GetComponent<CarController>().isControlleble)
                ClearRecord();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Car") && (this.GetComponent<CarController>().isControlleble))
        {
            levelController.ResetGame();
            if (this.GetComponent<CarController>().isControlleble)          
                ClearRecord();         
        }
    }

    public void ClearRecord()
    {
        CarRecord.ActionReplayRecords[this.GetComponent<CarController>().carNumber].Clear();
    }

    public void Record()
    {
        CarRecord.ActionReplayRecords[spawner.carNumber - 1].Add(new ActionReplayRecord { Position = transform.position, Rotation = transform.rotation });
    }
}

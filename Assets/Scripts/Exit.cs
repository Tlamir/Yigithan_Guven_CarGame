using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exit : MonoBehaviour
{


    private void OnTriggerEnter(Collider other)
    {
        GameObject[] cars = GameObject.FindGameObjectsWithTag("Car");
        foreach (GameObject car in cars)
            GameObject.Destroy(car);

        Destroy(this.gameObject);
    }
}
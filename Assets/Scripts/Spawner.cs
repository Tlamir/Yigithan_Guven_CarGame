using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    public GameObject Car;
    public GameObject Exit;

    public Vector3[] CarSpawnLocations = new Vector3[8];
    public Vector3[] ExitSpawnLocations = new Vector3[8];



    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 8; i++)
        {
            Instantiate(Car, CarSpawnLocations[i], Quaternion.identity);
        }
    }
}

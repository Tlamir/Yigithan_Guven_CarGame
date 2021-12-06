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
            GameObject car = Instantiate(Car, CarSpawnLocations[i], Quaternion.identity);
            car.GetComponent<CarController>().carNumber = i;
            if (i == carNumberr)
                car.GetComponent<CarController>().isControlleble = true;
            else
                car.GetComponent<CarController>().isControlleble = false;
        }
        carNumber++;
    }

    public void SpawnExit(int exitNumber)
    {
        if (exitNumber < 9)
            Instantiate(Exit, ExitSpawnLocations[exitNumber - 1], Quaternion.identity);
    }
}

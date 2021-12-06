using UnityEngine;

public class Exit : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<CarController>().isControlleble)
        {
            GameObject[] cars = GameObject.FindGameObjectsWithTag("Car");
            foreach (GameObject car in cars)
                GameObject.Destroy(car);

            Destroy(this.gameObject);
        }
    }
}
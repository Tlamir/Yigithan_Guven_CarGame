using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    //Upon collision with another GameObject
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Exit"))
        {
            Debug.Log("Yay it worked!! Spawn next car");
        }

        if (other.gameObject.CompareTag("Building"))
        {
            Debug.Log("Restart");
        }
    }
}

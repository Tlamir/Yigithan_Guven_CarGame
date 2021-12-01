using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    public Rigidbody rb;
    public float speed = 1.5f;


    Vector3 rotationRight = new Vector3(0, 60, 0);
    Vector3 rotationLeft = new Vector3(0, -60, 0);
    Vector3 forward = new Vector3(0, 0, 1);

    // Update is called once per frame
    void Update()
    {
        MoveStraight();

        if (Input.GetKey("d"))
            MoveRight();
        if (Input.GetKey("a"))
            MoveLeft();
    }

    void MoveLeft(){
        Quaternion deltaRotationLeft = Quaternion.Euler(rotationLeft * Time.deltaTime);
        rb.MoveRotation(rb.rotation * deltaRotationLeft);
    }

    void MoveRight(){
        Quaternion deltaRotationRight = Quaternion.Euler(rotationRight * Time.deltaTime);
        rb.MoveRotation(rb.rotation * deltaRotationRight);
    }

    void MoveStraight(){
        transform.Translate(forward * speed * Time.deltaTime);
    }

    //Upon collision with another GameObject
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Exit"))
        {
            Debug.Log("Yay it worked!!");
        }

        if (other.gameObject.CompareTag("Building"))
        {
            Debug.Log("Restart");
        }
    }


}

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

    private bool isFreezed = true;

    // Update is called once per frame
    void Update()
    {
        MoveStraight();

        if (Input.GetKey("d"))
        {
            MoveRight();
            isFreezed = false;
        }
            
        if (Input.GetKey("a"))
        {
            MoveLeft();
            isFreezed = false;
        }     
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
        if (!isFreezed)
        transform.Translate(forward * speed * Time.deltaTime);
    }

}

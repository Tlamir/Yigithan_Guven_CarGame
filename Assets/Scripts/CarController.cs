using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    public Rigidbody rb;

    
    Vector3 rotationRight = new Vector3(0, 60, 0);
    Vector3 rotationLeft = new Vector3(0, -60, 0);
    Vector3 forward = new Vector3(0, 0, 1);

    private bool isTouchedMobile=false;
    public float speed = 1.5f;
    public bool isFreezed = true;
    public bool isControlleble = true;

    // Update is called once per frame
    void Update()
    {
        /*if (isControlleble )
        {
            
            MoveStraight();

            if (Input.GetKey("d") )
            {
                MoveRight();
                isFreezed = false;
            }

            if (Input.GetKey("a") )
            {
                MoveLeft();
                isFreezed = false;
            }

        }
        else
        {
            if (!isFreezed)
            {
                //replay here
            }
        }*/


        //Mobile Controls
        if (isControlleble)
        {
            if(!isFreezed)
                MoveStraight();
            if (Input.touchCount > 0)
            {
                    var touch = Input.GetTouch(0);
                if (touch.position.x < Screen.width / 2)
                {
                    MoveLeft();
                    isFreezed = false;

                }
                else if (touch.position.x > Screen.width / 2)
                {
                    MoveRight();
                    isFreezed = false;
                }
            }
            
        }
        else
        {
            if (!isFreezed)
            {
                //replay here
            }
        }
        
        //Mobile Controls End










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
        {
            transform.Translate(forward * speed * Time.deltaTime);
            
        }
       
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    public Rigidbody rb;
    CarRecord CarRecord;
    Spawner Spawner;


    Vector3 rotationRight = new Vector3(0, 70, 0);
    Vector3 rotationLeft = new Vector3(0, -70, 0);
    Vector3 forward = new Vector3(0, 0, 1);

    public float speed = 1.5f;
    public bool isFreezed = true;
    public bool isControlleble = true;
    public int index = 0;
    public int carNumber = 0;


    void Start()
    {
        CarRecord = GameObject.FindGameObjectWithTag("CarRecord").GetComponent<CarRecord>();
        Spawner = GameObject.FindGameObjectWithTag("Spawner").GetComponent<Spawner>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isControlleble)
        {
            if (SystemInfo.deviceType == DeviceType.Desktop)
                DesktopControls();
            else
                MobileControls();
        }
        else if(!isFreezed)
        {
            SetTransform();
            //rb.isKinematic = true;
            
            
        }
        else //Test mobile 
        {
            if (Input.anyKey || Input.touchCount > 0)
            {
                isFreezed = false;
            }
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
       transform.Translate(forward * speed * Time.deltaTime);       
    }

    void MobileControls()
    {
       
            if (!isFreezed)
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

    void DesktopControls()
    {

            if (!isFreezed)
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




    private void SetTransform()
    {
        
        ActionReplayRecord actionReplayRecord = CarRecord.ActionReplayRecords[carNumber][index];

        if (CarRecord.ActionReplayRecords[carNumber].Count > index+1)
        {
            Debug.Log(CarRecord.ActionReplayRecords[carNumber].Count);
            transform.position = actionReplayRecord.Position;
            transform.rotation = actionReplayRecord.Rotation;
            index++;
        }

        
    }
}

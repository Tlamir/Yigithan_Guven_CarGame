using UnityEngine;

public class CarController : MonoBehaviour
{
    public Rigidbody rb;
    CarRecord CarRecord;


    Vector3 rotationRight = new Vector3(0, 115, 0);
    Vector3 rotationLeft = new Vector3(0, -115, 0);
    Vector3 forward = new Vector3(0, 0, 1);

    public int index = 0;
    public int carNumber = 0;
    public float speed = 1.5f;
    public bool isFreezed = true;
    public bool isControlleble = true;


    void Start()
    {
        CarRecord = GameObject.FindGameObjectWithTag("CarRecord").GetComponent<CarRecord>();
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
        else if (!isFreezed)
        {
            SetTransform();
        }
        else
        {
            if (Input.anyKey || Input.touchCount > 0)
            {
                isFreezed = false;
            }
        }
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

    void MoveLeft()
    {
        Quaternion deltaRotationLeft = Quaternion.Euler(rotationLeft * Time.deltaTime);
        rb.MoveRotation(rb.rotation * deltaRotationLeft);
    }

    void MoveRight()
    {
        Quaternion deltaRotationRight = Quaternion.Euler(rotationRight * Time.deltaTime);
        rb.MoveRotation(rb.rotation * deltaRotationRight);
    }

    void MoveStraight()
    {
        transform.Translate(forward * speed * Time.deltaTime);
    }

    //Play recorded movment
    private void SetTransform()
    {
        ActionReplayRecord actionReplayRecord = CarRecord.ActionReplayRecords[carNumber][index];

        if (CarRecord.ActionReplayRecords[carNumber].Count > index + 1)
        {
            transform.position = actionReplayRecord.Position;
            transform.rotation = actionReplayRecord.Rotation;
            index++;
        }
    }
}

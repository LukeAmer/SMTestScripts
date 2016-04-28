using UnityEngine;
using System.Collections;
using InControl;

public class Tank_TurretMovement : MonoBehaviour
{
    public float maxRot = 5.0f;
    public GameObject turret;

    float rotationSpeed = 0.0f;

	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        var inputDevice = InputManager.ActiveDevice;

        // Same as Tank Movement but rotate the Turret

        // Rotation
        if (inputDevice.RightStick.X > 0.1f || inputDevice.RightStick.X < -0.1f)
        {
            //RotateBase(inputDevice.LeftStick.X);
            ChangeRotAcc(inputDevice.RightStick.X);
        }
        else
        {
            DecreaseRotSpeed();
        }

        // Rotate
        RotateBase();

        // Rotate Turret Up and Down
        if (inputDevice.RightStick.Y > 0.1f || inputDevice.RightStick.Y < -0.1f)
        {

        }

    }

    void DecreaseRotSpeed()
    {
        rotationSpeed = Mathf.MoveTowards(rotationSpeed, 0.0f, 15.0f * Time.deltaTime);
    }

    void ChangeRotAcc(float dir)
    {
        if (Mathf.Abs(rotationSpeed) < maxRot)
        {
            if ((dir < 0.0f && rotationSpeed > 0.0f) || (dir > 0.0f && rotationSpeed < 0.0f))
                rotationSpeed += dir * 20.0f * Time.deltaTime;
            else
                rotationSpeed += dir * 5.0f * Time.deltaTime;
        }
    }

    void RotateBase()
    {
        gameObject.transform.Rotate(Vector3.up * rotationSpeed * 20.0f * Time.deltaTime);
    }
}

using UnityEngine;
using System.Collections;
using InControl;

public class Tank_Movement : MonoBehaviour
{
    public float maxSpeed = 2.0f;
    public float maxRot = 5.0f;

    [SerializeField]
    PlayerControl playerControl;

    float speed = 0.0f;
    float rotationSpeed = 0.0f;

	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        // Use last device which provided input.
        var inputDevice = playerControl.Device;

        if (inputDevice != null)
        {
            // Movement
            if (inputDevice.LeftStick.Y > 0.1f || inputDevice.LeftStick.Y < -0.1f)
            {
                // Update Acc
                ChangeAcc(inputDevice.LeftStick.Y);
            }
            else
            {
                // Decrease Acc
                DecreaseAcc();
            }

            // Move via translation from speed value
            Move();


            // Rotation
            if (inputDevice.LeftStick.X > 0.1f || inputDevice.LeftStick.X < -0.1f)
            {
                //RotateBase(inputDevice.LeftStick.X);
                ChangeRotAcc(inputDevice.LeftStick.X);
            }
            else
            {
                DecreaseRotSpeed();
            }

            // Rotate
            RotateBase();
        }

    }

    void Move()
    {
        // If speed is negative, then the tank moves backwards, otherwise the tank moves forwards -- Translation didn't work with rotation --

        gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, gameObject.transform.position + gameObject.transform.forward * 5.0f, speed * Time.deltaTime);
    }

    void DecreaseAcc()
    {
        // Slowy return speed value to 0
        speed = Mathf.MoveTowards(speed, 0.0f, 4.0f * Time.deltaTime);
    }

    void DecreaseRotSpeed()
    {
        rotationSpeed = Mathf.MoveTowards(rotationSpeed, 0.0f, 15.0f * Time.deltaTime);
    }

    void ChangeAcc(float dir)
    {
        // Use mathf to get the positive speed value and compare it to the max speed value
        if (Mathf.Abs(speed) < maxSpeed)
        {
            if((dir < 0.0f && speed > 0.0f) || (dir > 0.0f && speed < 0.0f))
                speed += dir * 7.0f * Time.deltaTime;
            else
                speed += dir * 2.0f * Time.deltaTime;
        }
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

using UnityEngine;
using System.Collections;
using InControl;

public class Tank_TurretMovement : MonoBehaviour
{
    public float maxRot = 5.0f;
    public GameObject turret;

    [SerializeField]
    PlayerControl playerControl;

    float rotationSpeed = 0.0f;

	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        var inputDevice = playerControl.Device;

        if (inputDevice != null)
        {

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
                if (CheckTurretAngle(inputDevice.RightStick.Y))
                    turret.transform.Rotate(Vector3.left * inputDevice.RightStick.Y * 40.0f * Time.deltaTime);
            }
        }
    }

    bool CheckTurretAngle(float dir)
    {
        float angle = turret.transform.localEulerAngles.x;
        angle = (angle > 180) ? angle - 360 : angle;

        //Debug.Log(angle);

        if(dir > 0)
        {
            if (angle > -50.0f)
                return true;
            else
                return false;
        }
        else
        {
            if (angle < 0.0f)
                return true;
            else
                return false;
        }
    }

    void DecreaseRotSpeed()
    {
        rotationSpeed = Mathf.MoveTowards(rotationSpeed, 0.0f, 20.0f * Time.deltaTime);
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
        gameObject.transform.Rotate(Vector3.up * rotationSpeed * 25.0f * Time.deltaTime);
    }
}

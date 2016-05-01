using UnityEngine;
using System.Collections;
using InControl;
using UnityEngine.UI;

public class Tank_Movement : MonoBehaviour
{
    public float maxSpeed = 2.0f;
    public float maxRot = 5.0f;
    public float sprintTime = 0.0f;
    public float sprintCooldownTime = 10.0f;

    [SerializeField]
    PlayerControl playerControl;

    float speed = 0.0f;
    float rotationSpeed = 0.0f;
    float sprintCooldown = 0.0f;
    bool isSprint = false;

    Player_UIControl playerUI;

	// Use this for initialization
	void Start ()
    {
        playerUI = gameObject.GetComponent<Player_UI>().UIControl;
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

            // Sprint
            if(inputDevice.LeftStickButton.IsPressed && sprintCooldown <= 0.0f && sprintTime <= 0.0f && !isSprint)
            {
                sprintTime = 5.0f;
                isSprint = true;

                maxSpeed *= 2.0f;
            }

            if(sprintTime > 0.0f)
            {
                sprintTime -= 1.0f * Time.deltaTime;

                playerUI.sprintCooldown.color = new Color(playerUI.sprintCooldown.color.r, playerUI.sprintCooldown.color.g, playerUI.sprintCooldown.color.b, 0.1f);

            }

            if (isSprint && sprintTime <= 0.0f)
            {
                isSprint = false;
                sprintCooldown = sprintCooldownTime;
                maxSpeed /= 2.0f;
            }

            if (sprintCooldown > 0.0f)
            {
                sprintCooldown -= 1.0f * Time.deltaTime;
                playerUI.sprintCooldown.color = new Color(playerUI.sprintCooldown.color.r, playerUI.sprintCooldown.color.g, playerUI.sprintCooldown.color.b, 0.1f);
            }

            if (sprintTime <= 0.0f && sprintCooldown <= 0.0f)
            {
                playerUI.sprintCooldown.color = new Color(playerUI.sprintCooldown.color.r, playerUI.sprintCooldown.color.g, playerUI.sprintCooldown.color.b, 0.8f);
            }


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
        else
        {
            DecreaseAcc();
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

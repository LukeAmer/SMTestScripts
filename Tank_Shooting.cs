using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using InControl;

public class Tank_Shooting : MonoBehaviour {

    public float powerSpeed = 0.0f;
    public float shotPower = 0.0f;
    public Slider powerSlider;
    public Transform turretPos;
    public GameObject Rocket;
    public bool fireBullet = false;
	// Use this for initialization


	void Start ()
    {
        powerSlider.value = shotPower;
	}
	
	// Update is called once per frame
	void Update ()
    {
        var inputDevice = InputManager.ActiveDevice;
        if (Input.GetKey(KeyCode.Space) || inputDevice.RightTrigger.IsPressed)
        {
            shotPower += powerSpeed * Time.deltaTime;

            if (shotPower >= 1000.0f)
            {
                shotPower = 1000.0f;
            }
            powerSlider.value = shotPower;
        } 

        if (fireBullet)
        {
            shotPower = 0.0f;
           powerSlider.value = shotPower;
            fireBullet = false;
        }
        Fire();

       // Debug.Log(inputDevice.RightBumper.IsPressed);
	}
    

    public void Fire()
    {
        var inputDevice = InputManager.ActiveDevice;
        if (inputDevice.RightTrigger.WasReleased)
        {
            
            GameObject bullet = (GameObject)Instantiate(Rocket, turretPos.transform.position, turretPos.rotation);
            bullet.name = Rocket.name;
            fireBullet = true;
        }

    }


}

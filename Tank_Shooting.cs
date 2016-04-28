using UnityEngine;
using System.Collections;
using UnityEngine.UI;

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
	    if (Input.GetKey(KeyCode.Space))
        {
            shotPower += powerSpeed * Time.deltaTime;

            if (shotPower >= 1000.0f)
            {
                shotPower = 1000.0f;
            }
            powerSlider.value = shotPower;
        }

        Fire();
	}
    

    public void Fire()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            GameObject bullet = (GameObject)Instantiate(Rocket, turretPos.transform.position, turretPos.rotation);
            bullet.name = Rocket.name;
        }

    }


}

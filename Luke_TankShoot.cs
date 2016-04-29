using UnityEngine;
using System.Collections;
using InControl;

public class Luke_TankShoot : MonoBehaviour
{
    [SerializeField]
    GameObject bullet;
    [SerializeField]
    GameObject bulletSpawn;
    [SerializeField]
    Animator turretPowerBar;
    [SerializeField]
    PlayerControl playerControl;

    float power = 10.0f;
    float cooldown = 0.0f;

    // Use this for initialization
    void Start ()
    {
	    
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        var inputDevice = playerControl.Device;

        if(inputDevice.RightTrigger.IsPressed && cooldown <= 0.0f)
        {
            // Power Up
            turretPowerBar.SetBool("IncreasePowerBar", true);

            // Still increasing?
            if(turretPowerBar.GetCurrentAnimatorStateInfo(0).IsName("PowerBar"))
            {
                power += 5.0f * Time.deltaTime;
                Debug.Log(power);
            }

        }
        else
        {
            if(power > 10.0f)
            {
                // Shoot
                Shoot();

                // Set Cooldown
                cooldown = 1.0f;
            }

            power = 10.0f;
            turretPowerBar.SetBool("IncreasePowerBar", false);
        }

        if(cooldown > 0.0f)
        {
            cooldown -= 1.0f * Time.deltaTime;
        }

    }

    void Shoot()
    {
        Debug.Log("SHOOT!");

        GameObject newBullet = Instantiate(bullet, bulletSpawn.transform.position, Quaternion.identity) as GameObject;
        newBullet.transform.rotation = bulletSpawn.transform.rotation;
        newBullet.GetComponent<Rigidbody>().AddForce(newBullet.transform.forward * power, ForceMode.Impulse);

    }
}

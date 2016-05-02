using UnityEngine;
using System.Collections;
using InControl;

public class Luke_TankShoot : MonoBehaviour
{
    public float powerIncreaseRate = 5.0f;
    public float cooldownTime = 1.0f;

    [SerializeField]
    GameObject bullet;
    [SerializeField]
    GameObject bulletSpawn;
    [SerializeField]
    Animator turretPowerBar;
    [SerializeField]
    Animator turretShootAnim;
    [SerializeField]
    GameObject aimAid;
    [SerializeField]
    Material[] aimAidMats;
    [SerializeField]
    PlayerControl playerControl;

    [SerializeField]
    GameObject shootSmokeEffect;
    [SerializeField]
    AudioClip shootSound;

    float power = 10.0f;
    float cooldown = 0.0f;

    AudioSource audioSource;

    // Use this for initialization
    void Start ()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        var inputDevice = playerControl.Device;

        if (inputDevice != null)
        {
            if (inputDevice.RightTrigger.IsPressed && cooldown <= 0.0f)
            {
                power += powerIncreaseRate * Time.deltaTime;
               // Debug.Log(power);
            }
                // Power Up
                turretPowerBar.SetBool("IncreasePowerBar", true);

                // Still increasing?
                if (turretPowerBar.GetCurrentAnimatorStateInfo(0).IsName("PowerBar"))
                {
                    power += powerIncreaseRate * Time.deltaTime;
                    Debug.Log(power);
                }


                aimAid.GetComponent<LineRenderer>().SetPosition(0, aimAid.transform.position);
                aimAid.GetComponent<LineRenderer>().SetPosition(1, aimAid.transform.position + aimAid.transform.forward * (power - 10.0f) / 2.0f);

                Material[] mats = aimAid.GetComponent<LineRenderer>().materials;
                mats[0] = aimAidMats[playerControl.playerNumber - 1];
                aimAid.GetComponent<LineRenderer>().materials = mats;

        }
        else
        {
            if(power > 10.0f && gameObject.GetComponent<Weapons_Select>().curWeaponState == Weapons_Select.weapons.Standard)
            {
                // Shoot
                Shoot(bullet);
                cooldown = cooldownTime;
            }
            if (power > 10.0f && gameObject.GetComponent<Weapons_Select>().curWeaponState == Weapons_Select.weapons.ExtraDamage)
            {
                // Shoot
                Shoot(bullet);

                // Set Cooldown
                cooldown = cooldownTime;
            }
            power = 10.0f;
            turretPowerBar.SetBool("IncreasePowerBar", false);
            aimAid.GetComponent<LineRenderer>().enabled = false;
        }
                aimAid.GetComponent<LineRenderer>().enabled = true;


            }
            else
            {
                if (power > 10.0f)
                {
                    // Shoot
                    Shoot();

                    // Set Cooldown
                    cooldown = cooldownTime;
                }

                power = 10.0f;
                turretPowerBar.SetBool("IncreasePowerBar", false);
                aimAid.GetComponent<LineRenderer>().enabled = false;
            }

            if (cooldown > 0.0f)
            {
                cooldown -= 1.0f * Time.deltatime;
            }
        }

    }

    void Shoot(GameObject Projectile)
    {
        Debug.Log("SHOOT!");

        GameObject newBullet = Instantiate(Projectile, bulletSpawn.transform.position, Quaternion.identity) as GameObject;
        newBullet.transform.rotation = bulletSpawn.transform.rotation;
        newBullet.GetComponent<BulletControl>().playerNumber = playerControl.playerNumber;
        newBullet.GetComponent<Rigidbody>().AddForce(newBullet.transform.forward * power, ForceMode.Impulse);

        turretShootAnim.SetTrigger("Shoot");
        audioSource.PlayOneShot(shootSound);

        GameObject newSmokeEffect = Instantiate(shootSmokeEffect, bulletSpawn.transform.position, Quaternion.identity) as GameObject;
    }
}

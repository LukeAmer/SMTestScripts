using UnityEngine;
using System.Collections;
using InControl;
using System.Collections.Generic;

public class Weapons_Select : MonoBehaviour {

    List<GameObject> Projectiles = new List<GameObject>();
    public enum weapons
    {
        Standard,
        extraDamage,


    };
    public int numOfWeapons = 1;
    public weapons curWeaponState;

	// Use this for initialization
	void Start ()
    {
       // InputManager.OnDeviceDetached += OnDeviceDetached;
    }
	
	// Update is called once per frame
	void Update ()
    {
        scrollWeapons();
        if (numOfWeapons == 0)
        {
            curWeaponState = weapons.Standard;
            gameObject.GetComponent<Luke_TankShoot>()._bulletDamage = 25;
            
        }
        if (numOfWeapons == 1)
        {
            curWeaponState = weapons.extraDamage ;
            gameObject.GetComponent<Luke_TankShoot>()._bulletDamage = 40;
        }
    }

    void scrollWeapons()
    {
        var inputDevice = InputManager.ActiveDevice;

        if (inputDevice.DPadRight.WasPressed)
        {
            numOfWeapons += 1;
        }
        if (inputDevice.DPadLeft.WasPressed)
        {
            numOfWeapons -= 1;
        }

        if (numOfWeapons > 1)
        {
            numOfWeapons = 1;
        }
        else if (numOfWeapons < 0)
        {
            numOfWeapons = 0;
        }
    }
}

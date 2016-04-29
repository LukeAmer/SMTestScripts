using UnityEngine;
using System.Collections;
using InControl;

public class Weapons_Select : MonoBehaviour {

    public enum weapons
    {
        Standard,
        burstFire,
        extraDamage,
        Kappa


    };
    public int numOfWeapons = 3;
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
        }
        if (numOfWeapons == 1)
        {
            curWeaponState = weapons.burstFire;

        }
        if (numOfWeapons == 2)
        {
            curWeaponState = weapons.extraDamage ;
        }
        if (numOfWeapons == 3)
        {
            curWeaponState = weapons.Kappa;
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

        if (numOfWeapons > 3)
        {
            numOfWeapons = 3;
        }
        else if (numOfWeapons < 0)
        {
            numOfWeapons = 0;
        }
    }
}

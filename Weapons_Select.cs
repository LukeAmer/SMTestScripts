using UnityEngine;
using System.Collections;
using InControl;

public class Weapons_Select : MonoBehaviour {

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
            GameObject.Find("Bullet 1").GetComponent<BulletControl>().bulletDamage = 25;
        }
        if (numOfWeapons == 1)
        {
            curWeaponState = weapons.extraDamage ;
            GameObject.Find("Bullet 1").GetComponent<BulletControl>().bulletDamage = 40;
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

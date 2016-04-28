using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Tank_Shooting : MonoBehaviour {

    public float powerSpeed = 0.0f;
    [SerializeField]private float shotPower = 0.0f;
    public Slider powerSlider;
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

            if (shotPower >= 100.0f)
            {
                shotPower = 100.0f;
            }
            powerSlider.value = shotPower;
        }
	}
}

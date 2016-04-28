using UnityEngine;
using System.Collections;

public class Bullet_Control : MonoBehaviour {


   private GameObject tank;
	// Use this for initialization
	void Start ()
    {
        tank = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update ()
    {
        transform.position += transform.forward * tank.GetComponent<Tank_Shooting>().shotPower * Time.deltaTime;
	}
}

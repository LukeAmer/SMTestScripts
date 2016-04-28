using UnityEngine;
using System.Collections;

public class Bullet_Control : MonoBehaviour {


    private float speed;
   private GameObject tank;
	// Use this for initialization
	void Start ()
    {
        tank = GameObject.FindGameObjectWithTag("Player");
        speed = tank.GetComponent<Tank_Shooting>().shotPower;
	}
	
	// Update is called once per frame
	void Update ()
    {
        transform.position += transform.forward * speed* Time.deltaTime;
	}
}

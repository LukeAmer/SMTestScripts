using UnityEngine;
using System.Collections;

public class PowerUps : MonoBehaviour {

    float RotSpeed = 100.0f;
    public  GameObject Tank;

    Tank_Movement tank_movement;

	// Use this for initialization
	void Start ()
    {
        tank_movement = Tank.GetComponent<Tank_Movement>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        transform.Rotate(Vector3.up, RotSpeed * Time.deltaTime);
	}

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == ("Tank(Clone)"))
        {
            Destroy(gameObject);
            tank_movement.maxSpeed = 10.0f;
            Debug.Log("Tank Collision");
        }

    }
}




using UnityEngine;
using System.Collections;

public class BulletControl : MonoBehaviour
{
    public int playerNumber = 1;

	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        if(gameObject.GetComponent<Rigidbody>().velocity.magnitude > 0.2f)
            transform.rotation = Quaternion.LookRotation(gameObject.GetComponent<Rigidbody>().velocity);
    }

    void OnCollisionEnter(Collision col)
    {
        // Explode and Destoy Bullet
        Destroy(gameObject);
    }

    void OnTriggerEnter(Collider col)
    {
        if(col.tag == "Tank")
        {
            // Check if hitting it's self
            if(col.gameObject.GetComponent<PlayerControl>().playerNumber != playerNumber)
            {
                Destroy(gameObject);
            }
        }
    }
}

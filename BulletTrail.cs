using UnityEngine;
using System.Collections;

public class BulletTrail : MonoBehaviour
{
    public GameObject targetBullet;

    TrailRenderer trail;
    float timeInAir = 0.0f;

	// Use this for initialization
	void Start ()
    {
        trail = gameObject.GetComponent<TrailRenderer>();
	}
	
	// Update is called once per frame
	void Update ()
    {
	    if(targetBullet != null)
        {
            timeInAir += 1.0f * Time.deltaTime;

            trail.time = 20.0f;

        }
        else
        {
            trail.time = timeInAir;

            Destroy(gameObject, timeInAir);
        }
	}
}

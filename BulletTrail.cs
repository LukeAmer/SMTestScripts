using UnityEngine;
using System.Collections;

public class BulletTrail : MonoBehaviour
{
    public GameObject targetBullet;

    [SerializeField]
    Material[] playerMats;

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
            Material[] mats = trail.materials;
            mats[0] = playerMats[targetBullet.GetComponent<BulletControl>().playerNumber - 1];
            trail.materials = mats;

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

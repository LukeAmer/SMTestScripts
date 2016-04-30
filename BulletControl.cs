using UnityEngine;
using System.Collections;

public class BulletControl : MonoBehaviour
{
    public int bulletDamage = 25;
    public GameObject hitEffect;
    public AudioClip hitSound;

    [HideInInspector]
    public int playerNumber = 1;

    [SerializeField]
    GameObject bulletTrail;

	// Use this for initialization
	void Start ()
    {
        GameObject newTrail = Instantiate(bulletTrail, gameObject.transform.position, Quaternion.identity) as GameObject;
        newTrail.GetComponent<BulletTrail>().targetBullet = gameObject;
        newTrail.transform.parent = gameObject.transform;
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
        GameObject newHitEffect = Instantiate(hitEffect, gameObject.transform.position + Vector3.up * 0.1f, Quaternion.identity) as GameObject;
        newHitEffect.transform.eulerAngles = Vector3.zero;

        GameObject audioSource = new GameObject();
        audioSource.name = "Bullet AudioSource";
        audioSource.transform.position = gameObject.transform.position;
        audioSource.AddComponent<AudioSource>();
        audioSource.GetComponent<AudioSource>().spatialBlend = 0.85f;
        audioSource.GetComponent<AudioSource>().PlayOneShot(hitSound);

        gameObject.GetComponentInChildren<TrailRenderer>().gameObject.transform.parent = null;

        Destroy(audioSource, 5.0f);

        Destroy(gameObject);
    }

    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "Tank")
        {
            PlayerControl tankHit = col.gameObject.transform.parent.gameObject.GetComponent<PlayerControl>();

            // Check if hitting it's self
            if(tankHit.playerNumber != playerNumber)
            {
                Debug.Log("Player Hit");

                GameObject newHitEffect = Instantiate(hitEffect, gameObject.transform.position, Quaternion.identity) as GameObject;
                newHitEffect.transform.eulerAngles = Vector3.zero;

                GameObject audioSource = new GameObject();
                audioSource.name = "Bullet AudioSource";
                audioSource.transform.position = gameObject.transform.position;
                audioSource.AddComponent<AudioSource>();
                audioSource.GetComponent<AudioSource>().spatialBlend = 0.85f;
                audioSource.GetComponent<AudioSource>().PlayOneShot(hitSound);

                gameObject.GetComponentInChildren<TrailRenderer>().gameObject.transform.parent = null;

                Destroy(audioSource, 5.0f);

                tankHit.gameObject.GetComponent<Rigidbody>().AddForce(gameObject.transform.forward * 5.0f, ForceMode.Impulse);

                tankHit.playerHealth -= bulletDamage;

                Destroy(gameObject);
            }
        }
    }
}

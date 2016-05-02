using UnityEngine;
using System.Collections;

public class BulletControl : MonoBehaviour
{
    public int bulletDamage;
    public float hitRadius = 5.0f;
    public GameObject hitEffect;
    public AudioClip hitSound;

    [HideInInspector]
    public int playerNumber = 1;

    [SerializeField]
    GameObject bulletTrail;

    public Weapons_Select weapon_Select;
	// Use this for initialization
	void Start ()
    {
        GameObject newTrail = Instantiate(bulletTrail, gameObject.transform.position, Quaternion.identity) as GameObject;
        newTrail.GetComponent<BulletTrail>().targetBullet = gameObject;
        newTrail.transform.parent = gameObject.transform;
        weapon_Select = GetComponent<Weapons_Select>();
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

        // Look for Nearby Tank
        Collider[] hitCols = Physics.OverlapSphere(gameObject.transform.position, hitRadius, 1 << 9, QueryTriggerInteraction.Collide);

        if(hitCols.Length > 0)
        {
            for(int i = 0; i < hitCols.Length; i++)
            {
                if(hitCols[i].gameObject.tag == "Tank" && hitCols[i].gameObject.transform.parent.gameObject.GetComponent<PlayerControl>() != null)
                {
                    PlayerControl tankHit = hitCols[i].gameObject.transform.parent.gameObject.GetComponent<PlayerControl>();

                    if (tankHit.playerNumber != playerNumber)
                    {
                        // Tank Hit
                        tankHit.gameObject.GetComponent<Rigidbody>().AddForce(gameObject.transform.forward * 5.0f, ForceMode.Impulse);

                        tankHit.playerHealth -= bulletDamage / 2;

                        Debug.Log("In-Direct hit!");
                    }
                }
            }
        }


        Destroy(gameObject);
    }

    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "Tank" && col.gameObject.transform.parent.gameObject.GetComponent<PlayerControl>() != null)
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

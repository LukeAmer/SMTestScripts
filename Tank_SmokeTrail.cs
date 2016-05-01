using UnityEngine;
using System.Collections;

public class Tank_SmokeTrail : MonoBehaviour
{
    [SerializeField]
    ParticleSystem smokeEffect;

    PlayerControl playerControl;

	// Use this for initialization
	void Start ()
    {
        playerControl = gameObject.GetComponent<PlayerControl>();
	}
	
	// Update is called once per frame
	void Update ()
    {
	    if(playerControl.playerHealth <= 25.0f)
        {
            if(!smokeEffect.isPlaying)
                smokeEffect.Play();
        }
        else
        {
            smokeEffect.Stop();
        }
	}
}

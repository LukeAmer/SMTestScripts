using UnityEngine;
using System.Collections;
using InControl;

public class PlayerControl : MonoBehaviour
{
    public int playerNumber = 100;
    public int playerHealth = 100;
    public enum playerStates { Alive, Dead}
    public playerStates playerState = playerStates.Alive;

    public InputDevice Device;

    [SerializeField]
    GameObject deathEffect;

    // Use this for initialization
    void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
	    if(playerHealth <= 0.0f && playerState == playerStates.Alive)
        {
            // Dead
            GameObject newDeathEffect = Instantiate(deathEffect, gameObject.transform.position, Quaternion.identity) as GameObject;

            playerState = playerStates.Dead;
            // Talk to playerManager?
            gameObject.SetActive(false);
        }
	}
}

using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Player_UI : MonoBehaviour
{
    public Player_UIControl UIControl;

    PlayerControl playerControl;


	// Use this for initialization
	void Start ()
    {
        playerControl = gameObject.GetComponent<PlayerControl>();
	}
	
	// Update is called once per frame
	void Update ()
    {
	    if(UIControl != null)
        {

            UIControl.health.text = playerControl.playerHealth.ToString();

        }
	}
}

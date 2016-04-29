using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using InControl;

public class PlayerManager : MonoBehaviour
{
    public List<PlayerControl> players;
    public GameObject testPlayer;

	// Use this for initialization
	void Start ()
    {
        InputManager.OnDeviceDetached += OnDeviceDetached;
    }
	
	// Update is called once per frame
	void Update ()
    {
        var inputDevice = InputManager.ActiveDevice;

        if(inputDevice.MenuWasPressed)
        {
            if(FindPlayerUsingDevice(inputDevice) == null)
            {
                players.Add(testPlayer.GetComponent<PlayerControl>());
                testPlayer.GetComponent<PlayerControl>().Device = inputDevice;
                testPlayer.SetActive(true);
            }
        }

        Debug.Log(players.Count);
    }

    PlayerControl FindPlayerUsingDevice(InputDevice device)
    {
        PlayerControl playerFound = null;

        for(int i = 0; i < players.Count; i++)
        {
            if (players[i].Device == device)
                playerFound = players[i];
        }

        return playerFound;
    }

    void OnDeviceDetached(InputDevice inputDevice)
    {
        PlayerControl player = FindPlayerUsingDevice(inputDevice);

        if(player != null)
        {
            player.Device = null;
            players.Remove(player);
        }
    }
}

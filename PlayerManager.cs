using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using InControl;

public class PlayerManager : MonoBehaviour
{
    public List<PlayerControl> connectedPlayers;
    public List<GameObject> totalPlayers;
    public GameObject playerTank;
    public GameObject[] playerSpawns;
    public Player_UIControl[] uiControls;

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
                if (CheckForPlayersWithoutDevice() != null)
                {
                    PlayerControl playerFound = CheckForPlayersWithoutDevice();

                    playerFound.Device = inputDevice;
                    connectedPlayers.Add(playerFound);
                }
                else
                {
                    // Spawn New Player Tank
                    GameObject newPlayer = Instantiate(playerTank, playerSpawns[totalPlayers.Count].transform.position, Quaternion.identity) as GameObject;
                    newPlayer.transform.eulerAngles = playerSpawns[totalPlayers.Count].transform.eulerAngles;

                    connectedPlayers.Add(newPlayer.GetComponent<PlayerControl>());
                    totalPlayers.Add(newPlayer);

                    newPlayer.GetComponent<PlayerControl>().Device = inputDevice;

                    if (newPlayer.GetComponent<PlayerControl>().playerNumber == 100)
                    {
                        newPlayer.GetComponent<PlayerControl>().playerNumber = totalPlayers.Count;
                        newPlayer.GetComponent<Player_UI>().UIControl = uiControls[totalPlayers.Count - 1];
                    }
                }

            }
        }

        //Debug.Log(connectedPlayers.Count);
    }

    PlayerControl FindPlayerUsingDevice(InputDevice device)
    {
        PlayerControl playerFound = null;

        for(int i = 0; i < connectedPlayers.Count; i++)
        {
            if (connectedPlayers[i].Device == device)
                playerFound = connectedPlayers[i];
        }

        return playerFound;
    }

    void OnDeviceDetached(InputDevice inputDevice)
    {
        // Unity Detaches both controllers when one controller has been disconnected 
        PlayerControl player = FindPlayerUsingDevice(inputDevice);

        if(player != null)
        {
            Debug.Log("Controller Removed");
            player.Device = null;
            connectedPlayers.Remove(player);
        }
    }

    PlayerControl CheckForPlayersWithoutDevice()
    {
        PlayerControl playerFound = null;

        for(int i = 0; i < totalPlayers.Count; i++)
        {
            if(totalPlayers[i].GetComponent<PlayerControl>().Device == null)
            {
                playerFound = totalPlayers[i].GetComponent<PlayerControl>();
            }
        }

        return playerFound;
    }

}

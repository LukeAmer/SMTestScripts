using UnityEngine;
using System.Collections;

public class Tank_Mat : MonoBehaviour
{
    [SerializeField]
    Material[] playerMats;

    [SerializeField]
    MeshRenderer[] colourMeshes;

    PlayerControl playerControl;

	// Use this for initialization
	void Start ()
    {
        playerControl = gameObject.GetComponent<PlayerControl>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (playerControl.playerNumber != 100)
        {

            // Set Mat
            for (int i = 0; i < colourMeshes.Length; i++)
            {
                Material[] mats = colourMeshes[i].materials;
                mats[0] = playerMats[playerControl.playerNumber - 1];
                colourMeshes[i].materials = mats;
            }

        }

	}
}

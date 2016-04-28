using UnityEngine;
using System.Collections;

public class Turret_Rotation : MonoBehaviour {

    public float speed;
	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update () {
        float rotY = Input.GetAxis("9") * speed * Time.deltaTime;
        float rotY2 = Input.GetAxis("10") * speed * Time.deltaTime;

        if (Input.GetAxis("9") != 0)
        {

       // rotY = Mathf.Clamp(rotY, -60f, 60f);
        //transform.Rotate(0,rotY * speed *  Time.deltaTime,0);
        // transform.localEulerAngles = new Vector3(0, rotY *speed * Time.deltaTime, 0);
        transform.Rotate(0, -rotY, 0);
        //transform.rotation = rot;
        }
        if (Input.GetAxis("10") != 0)
        {
            // rotY = Mathf.Clamp(rotY, -60f, 60f);
            //transform.Rotate(0,rotY * speed *  Time.deltaTime,0);
            // transform.localEulerAngles = new Vector3(0, rotY *speed * Time.deltaTime, 0);
            transform.Rotate(0, rotY2, 0);
            //transform.rotation = rot;
        }

    }
}

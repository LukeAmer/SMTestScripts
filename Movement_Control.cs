﻿using UnityEngine;
using System.Collections;

public class Movement_Control : MonoBehaviour {

    public float moveSpeed;
    public float rotSpeed;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        float moveX = Input.GetAxis("JoyX") * moveSpeed * Time.deltaTime;
        float Vertical = Input.GetAxis("JoyY") * moveSpeed * Time.deltaTime;

        float moveY4 = Input.GetAxis("4th") * rotSpeed * Time.deltaTime;
        //float rotY = Input.GetAxis("RightJoyY") * move * Time.deltaTime;



        if (Input.GetAxis("JoyY") > 0)
        {
            // transform.position += new Vector3(0, 0, Vertical);
            //transform.localPosition += new Vector3(0, 0, Vertical);
            //transform.position =
            transform.localPosition += transform.forward * moveSpeed * Time.deltaTime;
        }
        else if (Input.GetAxis("JoyY") < 0)
        {
            transform.localPosition += -transform.forward * moveSpeed * Time.deltaTime;
        }
       // if (Input.GetAxis("JoyY") != 0)
       // {
       //     transform.Rotate(0, moveY4, 0);
       // }

        if (Input.GetAxis("4th") != 0)
        {
            transform.Rotate(0, moveY4, 0);
          //  transform.rotation = Quaternion.Slerp(Vertical, -Vertical, Time.deltaTime * 6);
        }

       







	}
}

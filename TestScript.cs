using UnityEngine;
using System.Collections;

public class TestScript : MonoBehaviour
{
    // Test Scripts

    float num = 100.0f;


    void Start()
    {

        num = num + 20.0f;
        num = 0.0f;
        Debug.Log("Result: " + num);

    }



}

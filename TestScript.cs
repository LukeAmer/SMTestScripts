using UnityEngine;
using System.Collections;

public class TestScript : MonoBehaviour
{
    // Test Scripts

    int num2 = 10;
    int num3 = 1;

    float num = 100.0f;


    void Start()
    {
        num2 *= 50;
        num2 = num2 + 20;
        
        Debug.Log(num2);

        Debug.Log("Alright m8?");

        num = num + 20.0f;
        num = 0.0f;
        Debug.Log("Result: " + num);

    }



}

using UnityEngine;
using System.Collections;

public class TestScript : MonoBehaviour
{
    // Test Scripts


    void Start()
    {
        int i = 20;

        AddNum(ref i);

        SubNum(ref i);

        TimesNum(ref i);

        Debug.Log("The Result is...");
        Debug.Log("Below...");
        Debug.Log("vvvvv");

        Debug.Log("**RESULT >>> " + i + " <<< RESULT**");

    }

    void AddNum(ref int num)
    {
        num += 5;
    }

    void SubNum(ref int num)
    {
        num -= 8;
    }

    void TimesNum(ref int num)
    {
        num *= 2;
    }

}

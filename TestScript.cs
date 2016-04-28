using UnityEngine;
using System.Collections;

public class TestScript : MonoBehaviour
{
    // Test Scripts

    private bool pls = false;
    int i = 20;
    void Start()
    {
        pls = true;
        int i = 30;



        AddNum(ref i);

        SubNum(ref i);

        TimesNum(ref i);

    }

    void Update()
    {
        if (pls)
        {
            SubNum(ref i);
            Debug.Log("**RESULT >>> " + i + " <<< RESULT**");
            pls = false;
        }
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

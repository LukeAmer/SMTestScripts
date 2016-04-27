using UnityEngine;
using System.Collections;

public class TestScript : MonoBehaviour
{
    // Test Scripts


    void Start()
    {
        int i = 10;

        AddNum(ref i);

        SubNum(ref i);

        Debug.Log(i);

    }

    void AddNum(ref int num)
    {
        num += 5;
    }

    void SubNum(ref int num)
    {
        num -= 8;
    }


}

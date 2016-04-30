using UnityEngine;
using System.Collections;
using DevConsole;


public class DevConsoleCommands : MonoBehaviour
{

	// Use this for initialization
	void Start ()
    {
        Console.AddCommand(new Command<string>("DEBUG_OUTPUT", DebugOutput));
    }
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    static void DebugOutput(string output)
    {
        Debug.Log(output);
    }
}

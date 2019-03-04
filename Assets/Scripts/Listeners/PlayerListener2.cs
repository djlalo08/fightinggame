using UnityEngine;
using System;

public class PlayerListener2 : KeyListener
{


    //called by GameLoop
    //RegistersCurrentKeyHits
    readonly string[] forbiddenKeys = { "Q", "W", "E", "A", "S", "D", "Z", "X", "C" };

    private bool isKeyEnabled = false;

    override public string GetInput()
    {
        //string temp = lastPressed;
        //lastPressed = "";
        //return temp;
        string str = "";



        foreach (KeyCode kcode in Enum.GetValues(typeof(KeyCode)))
        {

            if (Input.GetKeyDown(kcode))
            {
                if ( Input.GetKeyDown(KeyCode.Q) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.X) || Input.GetKeyDown(KeyCode.C)){
                     isKeyEnabled = false;
                }
                else{
                    isKeyEnabled = true;
                }

                if (isKeyEnabled)
                {
                    str += kcode;
                }
            }
        }
        if (!isEnabled) return "";
        return str;
    }

    public void Update()
    {
    }
}

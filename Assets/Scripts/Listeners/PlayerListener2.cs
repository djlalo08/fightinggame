using UnityEngine;
using System;

public class PlayerListener2 : KeyListener
{

    //called by GameLoop
    //RegistersCurrentKeyHits
    readonly string[] forbiddenKeys = { "Q", "W", "E", "A", "S", "D", "Z", "X", "C" };
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
                int pos = Array.IndexOf(forbiddenKeys, kcode);
                if (pos < 1)
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

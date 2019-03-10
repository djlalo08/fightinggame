using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerListener : KeyListener {

	//called by GameLoop
	//RegistersCurrentKeyHits

    private bool isKeyEnabled = false;

    override public string GetInput(){
        //string temp = lastPressed;
        //lastPressed = "";
        //return temp;
        string str = "";
        foreach (KeyCode kcode in Enum.GetValues(typeof(KeyCode)))
        {

            if (Input.GetKeyDown(kcode))
            {
                if ( Input.GetKeyDown(KeyCode.I) || Input.GetKeyDown(KeyCode.Comma) || Input.GetKeyDown(KeyCode.O) || Input.GetKeyDown(KeyCode.M) || Input.GetKeyDown(KeyCode.P) || Input.GetKeyDown(KeyCode.N) || Input.GetKeyDown(KeyCode.J) || Input.GetKeyDown(KeyCode.L) || Input.GetKeyDown(KeyCode.K)){
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerListener : KeyListener {

	//called by GameLoop
	//RegistersCurrentKeyHits

    override public string GetInput(){
        //string temp = lastPressed;
        //lastPressed = "";
        //return temp;
        string str = "";
        foreach(KeyCode kcode in Enum.GetValues(typeof(KeyCode))) {
            if(Input.GetKeyDown(kcode))
                str += kcode;
        }
        return str;
    }

    public void Update() {
    }
}

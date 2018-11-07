using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIListener : KeyListener{

	//called by GameLoop
	//RegistersCurrentKeyHits
    override public string GetInput(){
        return "";
	}
}
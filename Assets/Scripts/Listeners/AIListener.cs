using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIListener : KeyListener{

    public bool hasTyped;

	//called by GameLoop
	//RegistersCurrentKeyHits
    override public string GetInput() {
        if (!hasTyped){
            int x = (int)Mathf.Floor(Random.Range(1,8));
            string str = "";
            switch (x){
                case 1:
                    str = "J";
                    break;
                case 2:
                    str = "L";
                    break;
                case 3:
                    str = "P";
                    break;
                case 4:
                    str = "JJ";
                    break;
                case 5:
                    str = "LL";
                    break;
                case 6:
                    str = "K";
                    break;
                case 7:
                    str = "";
                    break;
            }
            hasTyped = true;
            if (!isEnabled) return "";
            return str;
        }
        return "";
	}
}

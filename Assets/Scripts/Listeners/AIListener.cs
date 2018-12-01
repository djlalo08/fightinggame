using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIListener : KeyListener{

    public bool hasTyped; 

	//called by GameLoop
	//RegistersCurrentKeyHits
    override public string GetInput(){
        if (!hasTyped){
            int x = (int)Mathf.Floor(Random.Range(1,8));
            string str = "";
            switch (x){
                case 1:
                    str = "A";
                    break;
                case 2:
                    str = "Semicolon";
                    break;
                case 3:
                    str = "Q";
                    break;
                case 4:
                    str = "AA";
                    break;
                case 5:
                    str = "SemicolonSemicolon";
                    break;
                case 6:
                    str = "B";
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